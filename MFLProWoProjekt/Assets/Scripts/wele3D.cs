using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wele3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager3d.instance.start)
        {
            Destroy(gameObject);
        }
        if (GameManager3d.instance.start)
        {
            Movevert(GameManager3d.instance.speed);
        }

        if (gameObject.transform.position.y >= 40)
        {
            GameManager3d.instance.start = false;
        }
    }
    void Movevert(float speed)
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.up;
    }
}
