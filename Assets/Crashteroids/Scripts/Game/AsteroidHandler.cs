using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHandler : MonoBehaviour
{



    #region Spawning Variables
    [SerializeField] private GameObject _asteroidPrefab;
    //[SerializeField] private Vector2 _xBounds;
    [SerializeField] private float _spawnTimer = Mathf.Infinity;//used to calculate time
    [SerializeField] private float _spawnDelay = 2f;//how many seconds until an asteroid can spawn
    public bool canSpawn = true;
    #endregion




    private void Update()
    {
        #region Asteroid Spawn Timer
        if (canSpawn == true)
        {
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnDelay)
            {
                _spawnTimer = 0f;   //Resets the timer
                Debug.Log("Trying to run spawn asteroids method");
                SpawnAsteroid();
            }
        }
        #endregion
    }

    public GameObject SpawnAsteroid()
    {
        Vector2 spawnBounds = new Vector2(15f, (Random.Range(10, -8f)));//Sets the spawn location within 

        var asteroid = Instantiate(_asteroidPrefab, spawnBounds, Quaternion.identity, this.transform);

        GameMGR.instance.astroidList.Add(asteroid);


        return asteroid;



    }



}
