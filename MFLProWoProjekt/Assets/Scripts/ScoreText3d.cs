using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText3d : MonoBehaviour
{
    public static int score;

    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager3d.instance != null)
        {
            score = GameManager3d.instance.scorereal;
        }
        text.text = "Score: " + score.ToString();
    }
}
