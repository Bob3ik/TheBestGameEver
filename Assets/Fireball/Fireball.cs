using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Fireball : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] private float _speed = 5;
    [SerializeField, Range(1f, 20f)] private float _lifeTime = 2.5f;
    [SerializeField, Range(1f, 20f)] private float _damage = 10f;

    private void Start()
    {
        Invoke("DestroyFireball", _lifeTime);
    }

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DeadDamage(_damage);
        }

        DestroyFireball();
    }

    private void MoveFixedUpdate() { transform.position += transform.forward * _speed * Time.fixedDeltaTime; }
    private void DestroyFireball() { Destroy(gameObject); }
}
