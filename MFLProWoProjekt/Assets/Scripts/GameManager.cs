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
    public float speed = 20;
    public float gravity = 80;
    private float score = 0;
    public int scorereal = 0;
    public int highScore = 0;
    public bool theend = false;
    public bool start = true;

    private int currentframe = 0;
    private float timer = 15;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScore = MenuHiScore.HiScore2D;
    }
    // Update is called once per frame
    void Update()
    {
        if (!theend && !start)
        {
            timer -= Time.deltaTime;

            score += Time.deltaTime;
            scorereal = (int)score;
            if (scorereal > highScore)
            {
                highScore = scorereal;
            }

            if (timer <= 0)
            {
                if (currentframe == 0)
                {
                    speed += Time.deltaTime;
                }
                currentframe += 1;
                if (currentframe == 10)
                {
                    currentframe = 0;
                }
            }

            gravity = 5 * speed;
        }

        if (gameOver)
        {
            SceneManager.LoadScene(2);
        }
    }
}
