using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement3d : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager3d.instance.gameOver == false)
        {
            Movement();
        }
    }

    void Movement()
    {
        gameObject.transform.position += GameManager3d.instance.speed * Time.deltaTime * Vector3.forward;
    }
}
