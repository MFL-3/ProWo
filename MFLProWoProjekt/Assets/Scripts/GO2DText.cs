using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GO2DText : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject highScoreText;

    private TextMeshProUGUI textScore;
    private TextMeshProUGUI textHiScore;

    private int score;
    public static int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = ScoreText.score;
        highScore = HighScoreText.highScore;
        textScore = scoreText.GetComponent<TextMeshProUGUI>();
        textHiScore = highScoreText.GetComponent<TextMeshProUGUI>();
        textScore.text = "Score: " + score.ToString();
        textHiScore.text = "High Score: " + highScore.ToString();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
