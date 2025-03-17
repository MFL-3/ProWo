using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement3d : MonoBehaviour
{
    [SerializeField] Camera cam;
    // Update is called once per frame
    void Update()
    {
        if (!GameManager3d.instance.start)
        {
            cam.enabled = true;
            Destroy(gameObject);
        }

    }
}
