using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMGR : MonoBehaviour
{
    #region Variables
    public int score;
    public Text scoreText;
    public Text finalScoreText;
   
    public AsteroidHandler _asteroidHandler;
    public List<GameObject> astroidList;
    public List<GameObject> bulletList;
    public static GameMGR instance;
    public GameObject gameUI;
    public GameObject postGameUI;

    #region Testing Setup
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private AsteroidBehaviour _asteroidPrefab;
    [SerializeField] private BulletBehaviour _bulletBehaviourPrefab;

    [SerializeField] private AsteroidHandler _asteroidHandlerPrefab;

    #endregion

    #endregion


    private void Awake()
    {
        instance = this; //creates a static instance of this class

        //if asteroidHandler is null finds AsteroidSpawn GameObject in scene and references the AsteroidHandler script from it
        _asteroidHandler ??= GameObject.Find("AsteroidSpawn").GetComponent<AsteroidHandler>();
        score = 0;
        UpdateScore();

    }

    #region GameSetUp

    public void StartGame()
    {
      //  Debug.Log("Starting game function");
        //clears astroidList
       astroidList.Clear();
        //clears bulletList
        bulletList.Clear();
        foreach (Transform transform in _asteroidHandler.transform) //finds all the transforms inside of the objectSpawnBehaviour transform
        {
            //destroys the transforms gameObject
            Destroy(transform.gameObject);
        }
        foreach (Transform transform in GameObject.Find("Bullets").transform) //finds all the transforms inside of the Bullet transform
        {
            //destroys the transforms gameObject
            Destroy(transform.gameObject);
        }
        //instantiate Player prefab using Resources.Load at the set position and rotation coordinates
        Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, -2, 0), Quaternion.Euler(90, -180, 0));
        //sets the score to 0
        score = 0;
        //sets objectSpawnBehaviour to true
        _asteroidHandler.canSpawn = true;
        //runs UpdateScoreText function
        Debug.Log(_asteroidHandler.canSpawn);
        UpdateScore();
    }

    public void EndGame()
    {
        //disables GameUI
        gameUI.SetActive(false);
        //enables GameOverUI
        postGameUI.SetActive(true);
        //updates gameOverScoreText text to Score: + score (converting it to string)
        finalScoreText.text = "Score: " + score.ToString();
        //sets AsteroidBehaviour shouldSpawn bool to false //this is to disable Astroids from moving when the game has ended
       // _asteroidHandler.shouldSpawn = false;
        foreach (GameObject asteroid in astroidList) //increments though spawnedObectsList
        {
            //sets the objects shouldMove bool to falses
            asteroid.GetComponent<AsteroidBehaviour>().shouldMove = false;
        }
        foreach (GameObject bullet in bulletList) //increments through bulletList
        {
            //sets the bullet shouldMove bool to false
            bullet.GetComponent<BulletBehaviour>().shouldMove = false;
        }
    }

    public void Quit()
    {
        Application.Quit();//Quits the game
    }
    #endregion



    #region Score
    public void IncreaseScore(int value)
    {
        score += value; //Adds the value to score.
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (scoreText)
        {
            //sets scoreText text to score (converting it to string)
            scoreText.text = score.ToString();
        }
       
        return;
    }
    #endregion

    #region Testing Set Up

    public PlayerController GetPlayer() //returns and instance of the _playerPrefab
    {
        return Instantiate<PlayerController>(_playerPrefab);
    }

    public AsteroidBehaviour GetAsteroid() //returns and instance of the _astroidPrefab
    {
        return Instantiate<AsteroidBehaviour>(_asteroidPrefab);
    }

    public BulletBehaviour GetBullet() //returns and instance of the _bulletPrefab
    {
        return Instantiate<BulletBehaviour>(_bulletBehaviourPrefab);
    }

    public AsteroidHandler GetAsteroidSpawn() //returns and instance of the _astroidSpawnPrefab
    {
        return Instantiate<AsteroidHandler>(_asteroidHandlerPrefab);
    }


    #endregion


}
