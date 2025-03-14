using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.theend && !GameManager.instance.start)
        {
            Movement();
        }
    }

    void Movement()
    {
        gameObject.transform.position += GameManager.instance.speed * Time.deltaTime * Vector3.right;
    }


}
