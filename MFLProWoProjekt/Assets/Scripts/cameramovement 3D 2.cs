using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement3D2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
