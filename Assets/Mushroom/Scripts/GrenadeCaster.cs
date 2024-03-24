using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    [SerializeField] private Rigidbody _grenadePrefab;
    [SerializeField] private Transform _grenadeSourceTransform;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(_grenadePrefab);
        }
    }
}
