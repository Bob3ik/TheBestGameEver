using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _damage = 50f;
    private float _maxSize = 12.5f;
    private float _speed = 10f;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void FixedUpdate()
    {
        transform.localScale += Vector3.one * Time.fixedDeltaTime * _speed;

        if (transform.localScale.x > _maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DeadDamage(_damage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DeadDamage(_damage);
        }
    }
}
