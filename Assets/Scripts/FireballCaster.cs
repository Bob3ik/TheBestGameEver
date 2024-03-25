using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float Damage = 10f;
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _fireballSource;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(_fireball, _fireballSource.position, _fireballSource.rotation);
            fireball.Damage = Damage;
        }
    }
}
