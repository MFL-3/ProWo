using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3d : MonoBehaviour
{
    [SerializeField] GameObject tile1;
    [SerializeField] GameObject tile2;
    [SerializeField] GameObject tile3;
    [SerializeField] GameObject tile5;
    [SerializeField] GameObject absperr;
    GameObject player;
    public Vector3 spawnposition1 = new Vector3(-20, 0, 0);
    public Vector3 spawnposition2 = Vector3.zero;
    public Vector3 spawnposition3 = new Vector3(20, 0, 0);
    //public Vector3 spawnposition4 = new Vector3(-30, 70, 980);
    public int nexttile1;
    public int nexttile2;
    public int nexttile3;
    public int prevtile1;
    public int prevtile2;
    public int prevtile3;
    public int prevprevtile1;
    public int prevprevtile2;
    public int prevprevtile3;
    public int currenttile1;
    public int currenttile2;
    public int currenttile3;

    private bool treppe1 = false;
    private bool treppe2 = false;
    private bool treppe3 = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager3d.instance.player3d;
        for (int i = 0; i < 9; i++)
        {
            Instantiate(tile1, spawnposition1, tile1.transform.rotation);
            Instantiate(tile1, spawnposition2, tile1.transform.rotation);
            Instantiate(tile1, spawnposition3, tile1.transform.rotation);
            spawnposition1 = new Vector3(-20, 0, spawnposition1.z + 20);
            spawnposition2 = new Vector3(0, 0, spawnposition2.z + 20);
            spawnposition3 = new Vector3(20, 0, spawnposition3.z + 20);
        }
        nexttile1 = Random.Range(1, 6);
        nexttile2 = Random.Range(1, 6);
        if (nexttile1 == 5 && nexttile2 == 5)
        {
            nexttile3 = Random.Range(1, 5);
        }
        else
        {
            nexttile3 = Random.Range(1, 6);
        }
            
        prevtile1 = 1;
        prevtile2 = 1;
        prevtile3 = 1;
        currenttile1 = 1;
        currenttile2 = 1;
        currenttile3 = 1;
        prevprevtile1 = 1;
        prevprevtile2 = 1;
        prevprevtile3 = 1;
        Place();
        //Instantiate(absperr, spawnposition4, absperr.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnposition1.z - player.transform.position.z <= 500)
        {
            Place();
        }

        //if (player.transform.position.z - spawnposition4.z  >= 500)
        //{
            //spawnposition4 = new Vector3(spawnposition4.x, spawnposition4.y, spawnposition4.z + 2000);
            //Instantiate(absperr, spawnposition4, absperr.transform.rotation);
        //}

    }

    void Place()
    {
        for (int i = 0; i < 100; i++)
        {
            //Spur1
            prevprevtile1 = prevtile1;
            prevtile1 = currenttile1;
            switch (nexttile1)
            {
                case 1:
                    Instantiate(tile1, spawnposition1, tile1.transform.rotation);
                    currenttile1 = nexttile1;
                    if (treppe1)
                    {
                        treppe1 = false;
                        nexttile1 = 1;
                    }
                    else if (nexttile2 == 5)
                    {
                        nexttile1 = Random.Range(1, 5);
                    }
                    else
                    {
                        nexttile1 = Random.Range(1, 6);
                    }
                    break;
                case 2:
                    Instantiate(tile2, new(-20, 10, spawnposition1.z), tile2.transform.rotation);
                    currenttile1 = nexttile1;
                    if (nexttile2 == 5)
                    {
                        nexttile1 = Random.Range(1, 5);
                    }
                    else
                    {
                        nexttile1 = Random.Range(1, 6);
                    }
                        
                    if (treppe1)
                    {
                        treppe1 = false;
                    }
                    break;
                case 3:
                    Instantiate(tile3, new(-20, 30, spawnposition1.z), tile3.transform.rotation);
                    currenttile1 = nexttile1;
                    if (prevtile1 == 2)
                    {
                        treppe1 = true;
                        nexttile1 = Random.Range(1, 5);
                        if (nexttile1 == 4)
                        {
                            nexttile1 = 5;
                        }
                    }
                    else
                    {
                        nexttile1 = 1;
                    }
                    break;
                case 4:
                    currenttile1 = nexttile1;
                    nexttile1 = 1;
                    break;
                case 5:
                    Instantiate(tile5, new(-20, 10, spawnposition1.z), tile5.transform.rotation);
                    currenttile1 = nexttile1;
                    if (prevtile1 == 2)
                    {
                        treppe1 = true;
                        nexttile1 = Random.Range(1, 5);
                        if (nexttile1 == 4)
                        {
                            nexttile1 = 5;
                        }
                    }
                    else
                    {
                        nexttile1 = 1;
                    }
                    break;
            }
            spawnposition1 = new Vector3(-20, 0, spawnposition1.z + 20);

            //Spur2
            prevprevtile2 = prevtile2;
            prevtile2 = currenttile2;
            switch (nexttile2)
            {
                case 1:
                    Instantiate(tile1, spawnposition2, tile1.transform.rotation);
                    currenttile2 = nexttile2;
                    if (treppe2)
                    {
                        treppe2 = false;
                        nexttile2 = 1;
                    }
                    else if (currenttile1 == 5)
                    {
                        nexttile2 = Random.Range(1, 5);
                    }
                    else
                    {
                        nexttile2 = Random.Range(1, 6);
                    }
                    break;
                case 2:
                    Instantiate(tile2, new(0, 10, spawnposition2.z), tile2.transform.rotation);
                    currenttile2 = nexttile2;

                    if (currenttile1 == 5)
                    {
                        nexttile2 = Random.Range(1, 5);
                    }
                    else
                    {
                        nexttile2 = Random.Range(1, 6);
                    }
                        
                    if (treppe2)
                    {
                        treppe2 = false;
                    }
                    break;
                case 3:
                    Instantiate(tile3, new(0, 30, spawnposition2.z), tile3.transform.rotation);
                    currenttile2 = nexttile2;
                    if (prevtile2 == 2)
                    {
                        treppe2 = true;
                        nexttile2 = Random.Range(1, 5);
                        if (nexttile2 == 4)
                        {
                            nexttile2 = 5;
                        }
                    }
                    else
                    {
                        nexttile2 = 1;
                    }
                    break;
                case 4:
                    currenttile2 = nexttile2;
                    nexttile2 = 1;
                    break;
                case 5:
                    Instantiate(tile5, new(0, 10, spawnposition2.z), tile5.transform.rotation);
                    currenttile2 = nexttile2;
                    if (prevtile2 == 2)
                    {
                        treppe2 = true;
                        nexttile2 = Random.Range(1, 5);
                        if (nexttile2 == 4)
                        {
                            nexttile2 = 5;
                        }
                    }
                    else
                    {
                        nexttile2 = 1;
                    }
                    break;
            }
            spawnposition2 = new Vector3(0, 0, spawnposition2.z + 20);

            //Spur3
            prevprevtile3 = prevtile3;
            prevtile3 = currenttile3;
            switch (nexttile3)
            {
                case 1:
                    Instantiate(tile1, spawnposition3, tile1.transform.rotation);
                    currenttile3 = nexttile3;
                    
                    if (treppe3)
                    {
                        treppe3 = false;
                        nexttile3 = 1;
                    }
                    else if ((nexttile1 == 5 && nexttile2 == 5) || currenttile2 == 5)
                    {
                        nexttile3 = Random.Range(1, 5);
                    }
                    else
                    {
                        nexttile3 = Random.Range(1, 6);
                    }
                    break;
                case 2:
                    Instantiate(tile2, new(20, 10, spawnposition3.z), tile2.transform.rotation);
                    currenttile3 = nexttile3;
                    
                    if (treppe3)
                    {
                        treppe3 = false;
                    }
                    if ((nexttile1 == 5 && nexttile2 == 5) || currenttile2 == 5)
                    {
                        nexttile3 = Random.Range(1, 5);
                    }
                    else
                    {
                        nexttile3 = Random.Range(1, 6);
                    }
                    break;
                case 3:
                    Instantiate(tile3, new(20, 30, spawnposition3.z), tile3.transform.rotation);
                    currenttile3 = nexttile3;
                    if (prevtile3 == 2)
                    {
                        treppe3 = true;
                        nexttile3 = Random.Range(1, 5);
                        if (nexttile3 == 4)
                        {
                            nexttile3 = 5;
                        }
                    }
                    else
                    {
                        nexttile3 = 1;
                    }
                    break;
                case 4:
                    currenttile3 = nexttile3;
                    nexttile3 = 1;
                    break;
                case 5:
                    Instantiate(tile5, new(20, 10, spawnposition3.z), tile5.transform.rotation);
                    currenttile3 = nexttile3;
                    if (prevtile3 == 2)
                    {
                        treppe3 = true;
                        nexttile3 = Random.Range(1, 5);
                        if (nexttile3 == 4)
                        {
                            nexttile3 = 5;
                        }
                    }
                    else
                    {
                        nexttile3 = 1;
                    }
                    break;
            }
            spawnposition3 = new Vector3(20, 0, spawnposition3.z + 20);
        }
    }
}
