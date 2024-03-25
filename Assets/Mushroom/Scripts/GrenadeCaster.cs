using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    [SerializeField] private Rigidbody _grenadePrefab;
    [SerializeField] private Transform _grenadeSourceTransform;

    public float Damage = 50f;
    private float _forse = 350f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(_grenadePrefab);
            grenade.transform.position = _grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(_grenadeSourceTransform.forward * _forse);
            grenade.GetComponent<Grenade>().Damage = Damage;
        }
    }
}
