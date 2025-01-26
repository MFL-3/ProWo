using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuHiScore : MonoBehaviour
{
    public static int HiScore2D = 0;

    [SerializeField] GameObject hi2D;

    private TextMeshProUGUI text2D;

    // Start is called before the first frame update
    void Start()
    {
        HiScore2D = GO2DText.highScore;
        text2D = hi2D.GetComponent<TextMeshProUGUI>();
        
        text2D.text = "High Score: " + HiScore2D;
    }

}
