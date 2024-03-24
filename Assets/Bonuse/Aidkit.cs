using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    [SerializeField, Range(10f, 100f)] private float _healAmount = 50f;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(_healAmount);
            Destroy(gameObject);
        }
    }
}
