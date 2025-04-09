using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wele3D : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!GameManager3d.instance.paused)
        {
            if (!GameManager3d.instance.start)
            {
                Destroy(gameObject);
            }
            else
            {
                Movevert(GameManager3d.instance.speed * 1.5f);
            }

            if (gameObject.transform.position.y >= 73)
            {
                GameManager3d.instance.start = false;
            }
        }
    }
    void Movevert(float speed)
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.up;
    }
}
