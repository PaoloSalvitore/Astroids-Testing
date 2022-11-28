using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private Transform _laserSpawnPoint;
    [SerializeField] private Transform _laserParent;
    [SerializeField] private float _shotTimer = Mathf.Infinity;
    [SerializeField] private float _timeBetweenShots = 0.6f;
    Vector3 moveDir;
    public float speed = 5f;
    CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _shotTimer += Time.deltaTime;

        CalculateMovement();
        Move(moveDir);

        if (Input.GetKey(KeyCode.Space) && _shotTimer >= _timeBetweenShots)
        {
            _shotTimer = 0;
            SpawnLaser();
        }
    }

    private void CalculateMovement()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveDir *= speed;
    }

    public void Move(Vector3 dir)
    {
        charController.Move(dir * Time.deltaTime);
    }

    public GameObject SpawnLaser()
    {
        var laser = Instantiate(_laserPrefab, _laserSpawnPoint.position, Quaternion.identity, _laserParent);
        return laser;
    }
}
