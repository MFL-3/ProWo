using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wele2d : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.start)
        {
            Movevert(GameManager.instance.speed);
        }
        else if (!GameManager.instance.theend)
        {
            Movement(GameManager.instance.speed);
        }
        else
        {
            Movement(GameManager.instance.speed * 2);
        }

        if(gameObject.transform.position.y >= 43)
        {
            GameManager.instance.start = false;
        }

    }
    void Movement(float speed)
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.right;
    }

    void Movevert(float speed)
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.up;
    }
}
