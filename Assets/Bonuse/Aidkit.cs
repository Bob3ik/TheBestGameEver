using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Aidkit : MonoBehaviour
{
    [SerializeField, Range(10f, 100f)] private float _healAmount = 50f;
    public static Action OnDestroyAidkit;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddHealth(_healAmount);
            OnDestroyAidkit?.Invoke();
            Destroy(gameObject);
        }
    }
}
