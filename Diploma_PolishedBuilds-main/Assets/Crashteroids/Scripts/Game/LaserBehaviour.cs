using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 4.5f;

    private void Update()
    {
        LaserScrollUp();

        if (this.transform.position.y >= 9f)
        {
            Destroy(this.gameObject);
        }
    }

    public void LaserScrollUp()
    {
        this.transform.position += (Vector3.up * _scrollSpeed) * Time.deltaTime;
    }
}
