using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3d : MonoBehaviour
{
    [SerializeField] GameObject tile1;
    [SerializeField] GameObject tile2;
    [SerializeField] GameObject tile3;
    [SerializeField] GameObject tile5;
    GameObject player;
    public Vector3 spawnposition1 = new Vector3(-20, 0, 0);
    public Vector3 spawnposition2 = Vector3.zero;
    public Vector3 spawnposition3 = new Vector3(20, 0, 0);
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
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
        if (nexttile1 == 5 && nexttile2 ==5)
        {
            nexttile3 = Random.Range(1, 4);
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
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnposition1.x - player.transform.position.x <= 100)
        {
            Place();
        }

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
                    if (prevprevtile1 == 2 && prevtile1 == 3)
                    {
                        nexttile1 = 1;
                    }
                    else
                    {
                        nexttile1 = Random.Range(1, 6);
                    }
                    break;
                case 2:
                    Instantiate(tile2, spawnposition1, tile2.transform.rotation);
                    currenttile1 = nexttile1;
                    nexttile1 = Random.Range(1, 5);
                    break;
                case 3:
                    Instantiate(tile3, spawnposition1, tile3.transform.rotation);
                    currenttile1 = nexttile1;
                    nexttile1 = 1;
                    break;
                case 4:
                    currenttile1 = nexttile1;
                    nexttile1 = 1;
                    break;
                case 5:
                    break;
            }
            spawnposition1 = new Vector3(spawnposition1.x + 20, -15, 0);

        }
    }
}
