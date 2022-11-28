using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private DuckMovement playerPrefab;
    [SerializeField] private ObjectBehaviour objectPrefab;
    [SerializeField] private LaserBehaviour laserPrefab;
    [SerializeField] private ObjectSpawnBehaviour objectSpawnPrefab;
    public DuckMovement GetPlayer()
    {
        return Instantiate<DuckMovement>(playerPrefab);
    }

    public ObjectBehaviour GetObject()
    {
        return Instantiate<ObjectBehaviour>(objectPrefab);
    }

    public LaserBehaviour GetLaser()
    {
        return Instantiate<LaserBehaviour>(laserPrefab);
    }

    public ObjectSpawnBehaviour GetObjectSpawn()
    {
        return Instantiate<ObjectSpawnBehaviour>(objectSpawnPrefab);
    }
}
