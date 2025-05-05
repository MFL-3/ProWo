using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hinderniss1 : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        GameManager3d.instance.theend = true;       
    }
}
