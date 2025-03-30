using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hinderniss : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        Debug.Log("Tile 3");
        GameManager.instance.theend = true;
    }
}
