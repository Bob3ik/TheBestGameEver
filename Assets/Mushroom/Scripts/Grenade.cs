using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField, Range(1f, 5f)] private float _delay = 2f;
    [SerializeField] private GameObject _explosionPrefab;
    public float Damage = 50f;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", 3);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(_explosionPrefab);
        explosion.transform.position = transform.position;
        explosion.GetComponent<Explosion>().Damage = Damage;
    }
}
