using System;
using System.Numerics;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _scrollSpeed = 3f;
    [SerializeField] private int _deathValue;
    [Range(0, 2)] private float _sizeScale, _speedScale, _rotateDir;

    private GameManager _gm;

    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        CreateScaleData();
        UpdateScaledData();
    }

    private void UpdateScaledData() //adjusts scrollSpeed and localScale based on the scaledata randomly generated
    {
        _scrollSpeed *= _speedScale;
        transform.localScale *= _sizeScale;
    }

    private void CreateScaleData() //creates a random scale amount for size, speed and rotation
    {
        float t = UnityEngine.Random.Range(0.5f, 1.5f);
        float r;
        float f = UnityEngine.Random.Range(0, 2);
        switch (f)
        {
            case 0:
                r = UnityEngine.Random.Range(10f, 30f);
                _rotateDir = r;
                break;
            case 1: 
                r = UnityEngine.Random.Range(-10f, -30f);
                _rotateDir = r;
                break;
        }
        
        _sizeScale = t;
        _speedScale = t;
    }

    private void Update()
    {
        ObjectScrollDown();
        ObjectRotation();
    }

    public void ObjectScrollDown() //updates the objects position to scroll downwards multiplied by the scrollSpeed value
    {
        this.transform.position += (UnityEngine.Vector3.down * _scrollSpeed) * Time.deltaTime;
    }

    public void ObjectRotation() //rotates 
    {
        transform.Rotate(0,0,_rotateDir * Time.deltaTime, Space.Self);
    }

    public void DestroyObject(GameObject obj) //destroys the passed in GameObject
    {
        //play sfx
        //display particlefx/animation
        Destroy(obj);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player": //if Player
                Debug.Log("PLAYER");
                //kill player
                break;
            case "Laser": //if Laser
                _gm.IncreaseScore(_deathValue); //perform IncreaseScore function
                DestroyObject(other.gameObject); //perform DestroyObject function with other.gameObject passed in
                DestroyObject(this.gameObject); //perform DestroyObject function with this.gameObject passed in
                break;
        }
    }
}