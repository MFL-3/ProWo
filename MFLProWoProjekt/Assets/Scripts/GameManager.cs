using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver = false;
    public bool ducked = false;
    public bool jumping = false;
    public bool theend = false;
    public bool start = true;

    public Vector3 duckposition;
    public Vector3 jumpposition;

    public GameObject player;

    public float speed = 30;
    public float gravity = 80;

    public int scorereal = 0;
    public int highScore = 0;

    private float timer = 15;
    private float score = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //highscore aus Start Menu
        highScore = MenuHiScore.HiScore2D;
    }
    // Update is called once per frame
    void Update()
    {
        //Im Spiel
        if (!theend && !start)
        {
            timer -= Time.deltaTime;

            //score erhoehen
            score += Time.deltaTime;
            //nur ganzzahlige Werte ausgeben
            scorereal = (int)score;
            //highscore
            if (scorereal > highScore)
            {
                highScore = scorereal;
            }

            //Ab 15 Sekunden 1 mal pro sekunde Geschwindigkeit erhoehen
            if (timer <= 0)
            {
                timer = 1;
                speed += 0.1f;
            }
            gravity = 5 * speed;
        }

        if (gameOver)
        {
            //Game Over Menu
            SceneManager.LoadScene(2);
        }
    }
}
