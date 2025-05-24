using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _enemyCount = 5;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnDelay;

    private int _spawnCount = 0;

    void Start()
    {
        _spawnCount = 0;
        InvokeRepeating("SpawnEnemy", 5, _spawnDelay);
    }

    private void SpawnEnemy()
    {
        _spawnCount++;
        if (_spawnCount > _enemyCount)
        {
            Destroy(gameObject);
        }

        GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
    }

    public float GetSpawnCount()
    { 
        return _spawnCount; 
    }
    public float GetAllSpawnCount()
    { 
        return _enemyCount; 
    }
}
