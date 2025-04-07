using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settingsopen : MonoBehaviour
{
    [SerializeField] GameObject panel;
    /*[SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject slider1;
    [SerializeField] GameObject slider2;
    //[SerializeField] GameObject buttontext;*/

    private TextMeshProUGUI t1;
    public void Opensettings()
    {
        /*t1 = buttontext.GetComponent<TextMeshProUGUI>();
        if (t1.text == "Open Settings")
        {
            t1.text = "Close Settings";
        }
        else
        {
            t1.text = "Open Settings";
        }*/

        /*text1.SetActive(!text1.activeSelf);
        text2.SetActive(!text2.activeSelf);
        text3.SetActive(!text3.activeSelf);
        text4.SetActive(!text4.activeSelf);
        slider1.SetActive(!slider1.activeSelf);
        slider2.SetActive(!slider2.activeSelf);*/

        panel.SetActive(!panel.activeSelf);
    }
}
