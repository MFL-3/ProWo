using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager3d.instance.oldspeed = GameManager3d.instance.speed;
        GameManager3d.instance.speed = 20;
        GameManager3d.instance.slowed = true;
    }
}
