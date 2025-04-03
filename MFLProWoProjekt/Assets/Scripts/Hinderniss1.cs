using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hinderniss1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z <= GameManager3d.instance.player3d.transform.position.z - 20 && gameObject != null && GameManager3d.instance.player3d != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter()
    {
        Debug.Log("3D");
        GameManager3d.instance.theend = true;       
    }
}
