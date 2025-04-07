using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hinderniss : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        GameManager.instance.theend = true;
    }
}
