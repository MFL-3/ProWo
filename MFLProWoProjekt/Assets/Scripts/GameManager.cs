using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool ducked = false;
    public bool ducking = false;
    public bool jumping = false; 
    public static GameManager instance;
    public Vector3 duckposition;
    public Vector3 jumpposition;
    public GameObject player;
    public int speed = 20;
    public int gravity = 80;
    private float score = 0;
    public int scorereal = 0;
    public int highScore = 0;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        highScore = MenuHiScore.HiScore2D;
        score += Time.deltaTime;
        scorereal = (int)score;
        if (scorereal > highScore)
        {
            highScore = scorereal;
        }

        if (score % 10 == 0 && scorereal != 0)
        {
            
            speed += 10;
            Debug.Log(speed);
        }

        gravity = 4 * speed;

        if (gameOver)
        {
            SceneManager.LoadScene(2);
        }
    }
}
