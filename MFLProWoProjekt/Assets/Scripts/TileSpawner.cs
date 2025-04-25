using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] GameObject tile1;
    [SerializeField] GameObject tile2;
    [SerializeField] GameObject tile3;

    private Vector3 spawnposition = new(0, -15, 0);

    private int nexttile;
    private int prevtile;
    private int prevprevtile;
    private int currenttile;

    private bool treppe = false;
    private bool wastreppe = false;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
        //ebene Flaeche als start
        for (int i = 0; i < 9; i++)
        {
            Instantiate(tile1, spawnposition, tile1.transform.rotation);
            spawnposition = new Vector3(spawnposition.x + 20, spawnposition.y, 0);   
        }

        nexttile = Random.Range(1, 5);
        prevtile = 1;
        currenttile = 1;
        prevprevtile = 1;
        Place();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (spawnposition.x - player.transform.position.x <= 100)
            {
                Place();
            }
        }       
    }

    void Place()
    {
        //100 tiles placen
        for (int i = 0; i< 100; i++)
        {
            //vorherige tiles aktualisieren
            prevprevtile = prevtile;
            prevtile = currenttile;
            switch (nexttile)
            {
                case 1:
                    Instantiate(tile1, spawnposition, tile1.transform.rotation);
                    currenttile = nexttile;
                    if (wastreppe)
                    {
                        wastreppe = false;
                    }
                    //treppe aus -> wastreppe an, kein Abgrund nach treppe
                    if (treppe)
                    {
                        treppe = false;
                        wastreppe = true;
                        nexttile = Random.Range(1, 4);
                    }
                    else
                    {
                        nexttile = Random.Range(1, 5);
                    }
                    break;
                case 2:
                    Instantiate(tile2, new(spawnposition.x - 10, spawnposition.y+2, spawnposition.z), tile2.transform.rotation);
                    if (treppe)
                    {
                        treppe = false;
                    }
                    currenttile = nexttile;
                    nexttile = Random.Range(1, 5);
                    break;
                case 3:
                    Instantiate(tile3, spawnposition, tile3.transform.rotation);
                    //treppe an, wenn davor tile2 oder wastreppe
                    if(currenttile == 2)
                    {
                        treppe = true;
                    }
                    if (wastreppe)
                    {
                        treppe = true;
                        wastreppe = false;
                    }
                    currenttile = nexttile;
                    if (treppe)
                    {
                        nexttile = Random.Range(1, 4);
                    }
                    else
                    {
                        nexttile = 1;
                    }
                    break;
                case 4:
                    currenttile = nexttile;
                    nexttile = 1;
                    break;
            }
            //spawnposition aktualisieren
            spawnposition = new(spawnposition.x + 20, -15, 0);
        }
    }
}
