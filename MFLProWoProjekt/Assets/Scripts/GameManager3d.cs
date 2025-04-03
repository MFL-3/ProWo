using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public bool paused = false;
    public bool wechselt = false;
    public bool strangeVersion;
    public bool strangewechsel;

    public Vector3 duckposition;
    public Vector3 jumpposition;

    public TextMeshProUGUI buttontext;

    public GameObject player3d;

    public float speed = 30;
    public float gravity;

    public int scorereal = 0;
    public int highScore = 0;

    private float timer = 15;
    private float score = 0;

    [SerializeField] GameObject block;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //highscore aus Start Menu
        highScore = MenuHiScore.HiScore3D;

        strangeVersion = Sliderscript.komischeversion;
        strangewechsel = Sliderscript.komischwechseln;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pausieren3D();
        }
        //Im Spiel
        if (!theend && !start && !paused)
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
            SceneManager.LoadScene(4);
        }
    }
    public void Pausieren3D()
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
