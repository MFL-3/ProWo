using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hinderniss1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z <= GameManager3d.instance.player3d.transform.position.z - 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager3d.instance.theend = true;       
    }
}
