using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    //Assign a variable to store the GameMGR script
    GameMGR _gameMGR;
    //Setup before each test
    [SetUp]
    public void Setup()
    {
        //Instantiate GameMGR prefab in scene
        GameObject gameMGR = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameMGR"));
        //Assign the GameMGR script to the variable

        _gameMGR = gameMGR.GetComponent<GameMGR>();
        //Now spawning the gameManager
        //_gameMGR.GetGameMGR();

    }
    //Destroy after each test
    [TearDown]
    public void TearDown()
    {
        //Destroy the GameMGR object from the heirarchy
        Object.Destroy(_gameMGR.gameObject);
    }


    [UnityTest]
    public IEnumerator PlayerMoveLeft() // Change to move Down
    {
        PlayerController player = _gameMGR.GetPlayer();
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
    public IEnumerator SpawnBullet()//Check if lazer spawned
    {
        PlayerController player = _gameMGR.GetPlayer();
        GameObject bullet = player.SpawnBullet();
        yield return new WaitForSeconds(0.5f);
        Assert.True(bullet.activeInHierarchy);
        yield return null;
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator SpawnAsteroids() //check if astroids spawned.
    {
        AsteroidHandler obj = _gameMGR.GetAsteroidSpawn();
        obj.SpawnAsteroid();
        yield return new WaitForSeconds(0.5f);
        Assert.IsNotNull(obj.SpawnAsteroid());
        yield return null;
        Object.Destroy(obj);
    }
}
