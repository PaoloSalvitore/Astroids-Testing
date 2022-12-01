using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform _bulletSpawnLocation;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _shotTimer = Mathf.Infinity;
    [SerializeField] private float _timeBetweenShots = 0.6f;
    Vector3 moveDir;
    public float moveSpeed = 6f;
    CharacterController charController;
    #endregion

    private void Awake()//initialize
    {
        if (!charController)//if its null then get the component
        {
            charController = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Calculates the shot timer
        _shotTimer += Time.deltaTime;

        //runs CalculateMovement function
        CalculateMovement();
        //Runs the move function and passes on the movement direction.
        Move(moveDir);

        //if user inputs Shoot key AND shot timer allows for a bullet
        if (Input.GetButton("P1 R1") && _shotTimer >= _timeBetweenShots)
        {
            //resets the timer for the new delay
            _shotTimer = 0;
            //runs SpawnBullet method
            SpawnBullet();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR//Quits if its in the unity editor.
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            GameMGR.instance.Quit();
        }
    }



    private void CalculateMovement()
    {
        //sets moveDir to a new Vector3 with x set to Horizontal Axis input and y set to Vertical Axis input
        moveDir = new Vector3(Input.GetAxisRaw("P1 Hori"), Input.GetAxisRaw("P1 Verti"), 0);
        //multiplies moveDir by speed
        moveDir *= moveSpeed;
    }

    public void Move(Vector3 dir)
    {
        //moves the player in the direction that is passed through.
        //multiplied by Time.deltaTime
        charController.Move(dir * Time.deltaTime);
    }

    public GameObject SpawnBullet()
    {
        //instantiates BulletPrefab at the bulletSpawnPoint position, parented to bullet GameObject in scene
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnLocation.position, Quaternion.identity);
        //adds bullet to GameManager spawnedBulletList
        GameMGR.instance.bulletList.Add(bullet);
        //returns bullet GameObject
        return bullet;
    }
}

