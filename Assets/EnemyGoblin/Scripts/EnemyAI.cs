using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private List<Transform> _patrolPoint;

    [SerializeField] private float _viewAngle;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed = false;

    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatroUpdate();
    }

    private void PickNewPatrolPoint() => _navMeshAgent.destination = _patrolPoint[Random.Range(0, _patrolPoint.Count)].position;

    private void NoticePlayerUpdate()
    {
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
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
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
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
