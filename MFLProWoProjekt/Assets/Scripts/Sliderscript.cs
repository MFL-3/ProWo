using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sliderscript : MonoBehaviour
{
    [SerializeField] Slider slider;
    public static bool komischeversion;
    
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
    }
}
