using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Transform> _patrolPoint;

    private NavMeshAgent _navMeshAgent;
    private PlayerController _player;
    private PlayerHealth _playerHealth;

    [SerializeField] private float _viewAngle;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _attackDistance = 1f;

    private bool _isPlayerNoticed = false;

    private void Start()
    {
        InitComponentLinks();
        //PickNewPatrolPoint();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatroUpdate();
    }

    //private void PickNewPatrolPoint() => _navMeshAgent.destination = _patrolPoint[Random.Range(0, _patrolPoint.Count)].position;

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        if (_playerHealth.Value <= 0) return;

        var direction = _player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < _viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == _player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void PatroUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                //PickNewPatrolPoint();
            }
        }
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _animator.SetTrigger("attack");
            }
        }
    }

    public void AttackDamage()
    {
        if (_playerHealth.Value > 0)
        {
            _playerHealth.DeadDamage(_damage);
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = _player.transform.position;
        }
    }

    private void InitComponentLinks()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }
}
