using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    [SerializeField] private Fireball _fireball;
    [SerializeField] private Transform _fireballSource;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_fireball, _fireballSource.position, _fireballSource.rotation);
        }
    }
}
