using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private Vector2 _xBounds;
    [SerializeField] private float _spawnTimer = Mathf.Infinity;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _timeBetweenSpawn)
        {
            _spawnTimer = 0f;
            SpawnObject();
        }
    }

    public GameObject SpawnObject()
    {
        Vector2 randomSpawnLocation = new Vector2(Random.Range(_xBounds.x, _xBounds.y), 9f);
        var asteroid = Instantiate(_asteroidPrefab, randomSpawnLocation, Quaternion.identity, this.transform);
        return asteroid;
    }
}
