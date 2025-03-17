using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3d : MonoBehaviour
{
    public static GameManager3d instance;

    public bool gameOver = false;
    public bool ducked = false;
    public bool jumping = false;
    public bool theend = false;
    public bool start = true;

    public Vector3 duckposition;
    public Vector3 jumpposition;

    public GameObject player3d;

    public float speed = 30;
    public float gravity = 80;

    public int scorereal = 0;
    public int highScore = 0;

    private float timer = 15;
    private float score = 0;
    private int currentframe = 0;

    [SerializeField] GameObject block;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //highscore aus Start Menu
        highScore = MenuHiScore.HiScore3D;
    }
    // Update is called once per frame
    void Update()
    {
        //Im Spiel
        if (!theend && !start)
        {
            timer -= Time.deltaTime;
            //Scre erhoehen
            score += Time.deltaTime;
            //nur ganzzahlige Werte ausgeben
            scorereal = (int)score;
            //highscore
            if (scorereal > highScore)
            {
                highScore = scorereal;
            }
            //Ab 15 Sekunden 10 mal pro sekunde Geschwindigkeit erhoehen
            if (timer <= 0)
            {
                if (currentframe == 0)
                {
                    speed += 2 * Time.deltaTime;
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
            SceneManager.LoadScene(4);
        }
    }
}
