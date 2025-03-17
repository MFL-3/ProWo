using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Twodopen : MonoBehaviour
{
    //2D-Szene laden
    public void Zweid()
    {
        SceneManager.LoadScene(1);
    }

    //3D-Szene laden
    public void Dreid()
    {
        SceneManager.LoadScene(3);
    }

    //Schliessen
    public void ExitGame()
    {
        Application.Quit();
    }
}
