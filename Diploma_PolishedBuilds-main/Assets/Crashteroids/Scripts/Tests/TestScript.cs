using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    //Assign a variable to store the GameHandler script
    GameHandler _gameHandler;
    //Setup before each test
    [SetUp]
    public void Setup()
    {
        //Instantiate GameHandler prefab in scene
        GameObject gameHandler = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameHandler"));
        //Assign the GameHandler script to the variable
        _gameHandler = gameHandler.GetComponent<GameHandler>();
    }
    //Destroy after each test
    [TearDown]
    public void TearDown()
    {
        //Destroy the GameHandler object from the heirarchy
        Object.Destroy(_gameHandler.gameObject);
    }
    
    [UnityTest]
    public IEnumerator PlayerMoveRight()
    {
        DuckMovement player = _gameHandler.GetPlayer();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        float initialXPos = player.transform.position.x;
        Vector3 dir = new Vector3(20f, 0, 0); 
        player.Move(dir);
        yield return new WaitForSeconds(0.5f);
        Assert.Greater(player.transform.position.x, initialXPos);
        yield return null;
        Object.Destroy(player);
    }
    
    [UnityTest]
    public IEnumerator PlayerMoveLeft()
    {
        DuckMovement player = _gameHandler.GetPlayer();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        float initialXPos = player.transform.position.x;
        Vector3 dir = new Vector3(-20f, 0, 0); 
        player.Move(dir);
        yield return new WaitForSeconds(0.5f);
        Assert.Less(player.transform.position.x, initialXPos);
        yield return null;
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator ObjectMoveDown()
    {
        ObjectBehaviour obj = _gameHandler.GetObject();
        float initialYPos = obj.transform.position.y;
        obj.ObjectScrollDown();
        yield return new WaitForSeconds(0.5f);
        Assert.Less(obj.transform.position.y, initialYPos);
        yield return null;
        Object.Destroy(obj);
    }

    [UnityTest]
    public IEnumerator LaserMoveUp()
    {
        LaserBehaviour laser = _gameHandler.GetLaser();
        float initialYPos = laser.transform.position.y;
        laser.LaserScrollUp();
        yield return new WaitForSeconds(0.5f);
        Assert.Greater(laser.transform.position.y, initialYPos);
        yield return null;
        Object.Destroy(laser);
    }

    [UnityTest]
    public IEnumerator SpawnLaser()
    {
        DuckMovement player = _gameHandler.GetPlayer();
        player.SpawnLaser();
        yield return new WaitForSeconds(0.5f);
        Assert.True(player.SpawnLaser().activeInHierarchy);
        yield return null;
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator SpawnObject()
    {
        ObjectSpawnBehaviour obj = _gameHandler.GetObjectSpawn();
        obj.SpawnObject();
        yield return new WaitForSeconds(0.5f);
        Assert.IsNotNull(obj.SpawnObject());
        yield return null;
        Object.Destroy(obj);
    }
}
