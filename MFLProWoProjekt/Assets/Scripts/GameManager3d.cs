using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3d : MonoBehaviour
{
    public bool gameOver = false;
    public bool ducked = false;
    public bool ducking = false;
    public bool jumping = false;
    public static GameManager3d instance;
    public Vector3 duckposition;
    public Vector3 jumpposition;
    public GameObject player3d;
    public float speed = 30;
    public float gravity = 80;
    private float score = 0;
    public int scorereal = 0;
    public int highScore = 0;

    private int currentframe = 0;
    private float timer = 15;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        highScore = MenuHiScore.HiScore3D;
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
                speed += 2* Time.deltaTime;
            }
            currentframe += 1;
            if (currentframe == 10)
            {
                currentframe = 0;
            }
        }

        gravity = 5 * speed;

        if (gameOver)
        {
            SceneManager.LoadScene(4);
        }
    }
}
