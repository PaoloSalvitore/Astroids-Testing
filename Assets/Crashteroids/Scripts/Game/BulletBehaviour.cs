using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 8.5f;
    public bool shouldMove = true; //used to determine if the game is active(Post game this is false)

    private void Update()
    {
        if (shouldMove) //if shouldMove is true
        {
            BulletMovement(); //Moves bullet -> Right
        }

        if (this.transform.position.x >= 35f) //Destroy bullet if it goes to X.35 position
        {
            DestroyBullet(); //Destroys bullet
        }
    }

    private void DestroyBullet() //Goes through the spawnedList and deletes bullets
    {
        for (int i = 0; i < GameMGR.instance.bulletList.Count; i++) //increments through bulletList 
        {
            if (GameMGR.instance.bulletList[i] == this.gameObject) //if this gameObject matches the gameObject in bulletList at index i
            {
                GameMGR.instance.bulletList.RemoveAt(i); //removes the bullet from the list.
            }
        }
        Destroy(this.gameObject); //destroys this gameObject
    }

    public void BulletMovement()
    {
        //translates the transform with the Vector3 coordinates multiplied by scrollSpeed and Time.deltaTime 
        this.transform.position += (Vector3.right * _bulletSpeed) * Time.deltaTime;
    }
}
