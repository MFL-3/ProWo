using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuHiScore : MonoBehaviour
{
    public static int HiScore2D = 0;

    [SerializeField] GameObject hi2D;

    private TextMeshProUGUI text2D;


    //3D
    public static int HiScore3D = 0;

    [SerializeField] GameObject hi3D;

    private TextMeshProUGUI text3D;

    // Start is called before the first frame update
    void Start()
    {
        HiScore2D = GO2DText.highScore;
        text2D = hi2D.GetComponent<TextMeshProUGUI>();
        
        text2D.text = "High Score: " + HiScore2D;

        //3D
        HiScore3D = GO3DText.highScore;
        text3D = hi3D.GetComponent<TextMeshProUGUI>();

        text3D.text = "High Score: " + HiScore3D;
    }

}
