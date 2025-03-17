using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class welle3ddeath : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(!GameManager3d.instance.theend)
        {
            Movement(GameManager3d.instance.speed);
        }
        else
        {
            Movement(GameManager3d.instance.speed * 8);
        }

    }

    void Movement(float speed)
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.forward;
    }
}
