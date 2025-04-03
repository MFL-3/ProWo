using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = Bildschirm.mode;
    }
}
