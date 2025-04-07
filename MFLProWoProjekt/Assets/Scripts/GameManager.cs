using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public bool paused = false;
    public bool falling = false;
    public bool strangeVersion;

    public Vector3 duckposition;
    public Vector3 jumpposition;

    public TextMeshProUGUI buttontext;

    public GameObject player;

    public float speed = 30;
    public float gravity;

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

        strangeVersion = Sliderscript.komischeversion;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pausieren();
        }
        //Im Spiel
        if (!theend && !start && !paused)
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
            gravity = (speed * speed * 80) / 239.9401f;
        }

        if (gameOver)
        {
            //Game Over Menu
            SceneManager.LoadScene(2);
        }
    }

    public void Pausieren()
    {
        paused = !paused;
        if (paused)
        {
            buttontext.text = "Play";
        }
        else
        {
            buttontext.text = "Pause";
        }
    }
}
