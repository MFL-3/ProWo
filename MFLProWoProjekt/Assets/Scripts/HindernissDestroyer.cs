using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindernissDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            Destroy(other.gameObject);
        }
    }
}
