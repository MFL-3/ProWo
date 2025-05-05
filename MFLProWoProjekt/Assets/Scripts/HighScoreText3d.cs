using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreText3d : MonoBehaviour
{
    public static int highScore;

    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager3d.instance != null)
        {
            highScore = GameManager3d.instance.highScore;
        }
        text.text = "High Score: " + highScore.ToString();
    }
}
