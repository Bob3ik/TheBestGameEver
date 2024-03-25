using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(8);
        InstantiateEnemy();
    }

    private void InstantiateEnemy() { Instantiate(_enemy, _spawnPoint[Random.Range(0, _spawnPoint.Length)].position, Quaternion.identity); }
}
