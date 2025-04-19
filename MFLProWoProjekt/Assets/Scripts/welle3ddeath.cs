using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welle3ddeath : MonoBehaviour
{
    private float myspeed;
    void Start()
    {
        myspeed = GameManager3d.instance.speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager3d.instance.paused)
        {
            if (!GameManager3d.instance.theend)
            {
                Movement(myspeed);
            }
            else
            {
                Movement(myspeed * 6);
            }
        }
    }

    void Movement(float speed)
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.forward;
    }
}
