using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement3D2 : MonoBehaviour
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
        gameObject.transform.position = new Vector3(GameManager3d.instance.player3d.transform.position.x, GameManager3d.instance.player3d.transform.position.y + 48, GameManager3d.instance.player3d.transform.position.z - 25);
    }
}
