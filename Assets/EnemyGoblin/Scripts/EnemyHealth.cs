using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] public float Value;
    private PlayerProgress _playerProgress;

    private void Start()
    {
        _playerProgress = FindObjectOfType<PlayerProgress>();
    }

    public void DeadDamage(float damage)
    {
        _playerProgress.AddExperience(damage);

        Value -= damage;
        if (Value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            _animator.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        _animator.SetTrigger("death");
        gameObject.GetComponent<EnemyAI>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
