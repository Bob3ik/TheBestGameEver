using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    [SerializeField] private Aidkit _aidkit;
    [SerializeField] private Transform[] _spawnPoint;
    private int _numberPoint;

    private void OnEnable()
    {
        Aidkit.OnDestroyAidkit += SpawnAidkit;   
    }

    private void OnDisable()
    {
        Aidkit.OnDestroyAidkit -= SpawnAidkit;
    }

    private void Start()
    {
        SpawnAidkit();
    }

    private void SpawnAidkit()
    {
        int point = Random.Range(0, _spawnPoint.Length);
        while (point == _numberPoint)
            point = Random.Range(0, _spawnPoint.Length);

        Instantiate(_aidkit, _spawnPoint[point].position, Quaternion.identity);
        _numberPoint = point;
    }
}
