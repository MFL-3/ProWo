using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sliderscript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Slider slider2;
    public static bool komischeversion;
    public static bool komischwechseln;
    
    // Start is called before the first frame update
    void Start()
    {
        if (komischeversion)
        {
            slider.value = 1;
        }
        else
        {
            slider.value = 0;
        }

        if (komischwechseln)
        {
            slider2.value = 1;
        }
        else
        {
            slider2.value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0)
        {
            komischeversion = false;
        }
        else
        {
            komischeversion = true;
        }

        if (slider2.value == 0)
        {
            komischwechseln = false;
        }
        else
        {
            komischwechseln = true;
        }
    }
}
