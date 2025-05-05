using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindernissDestroyer3D : MonoBehaviour
{
    void Update()
    {
        if (GameManager3d.instance.player3d != null)
        {
            if (gameObject.transform.position.z <= GameManager3d.instance.player3d.transform.position.z - 20)
            {
                Destroy(gameObject);
            }
        }
    }
}
