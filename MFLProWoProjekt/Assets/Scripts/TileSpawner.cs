using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    GameObject player;
    public Vector3 spawnposition = new Vector3(0, -15, 0);
    public int nexttile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
        for (int i = 0; i < 9; i++)
        {
            Instantiate(tile1, spawnposition, tile1.transform.rotation);
            spawnposition = new Vector3(spawnposition.x + 20, spawnposition.y, 0);   
        }
        nexttile = Random.Range(1, 5);
        Place();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnposition.x - player.transform.position.x <= 100)
        {
            Place();
        }
               
    }

    void Place()
    {
        for (int i = 0; i< 100; i++)
        {
            switch (nexttile)
            {
                case 1:
                    Instantiate(tile1, spawnposition, tile1.transform.rotation);
                    nexttile = Random.Range(1, 5);
                    break;
                case 2:
                    Instantiate(tile2, spawnposition, tile2.transform.rotation);
                    nexttile = Random.Range(1, 5);
                    break;
                case 3:
                    Instantiate(tile3, spawnposition, tile3.transform.rotation);
                    nexttile = 1;
                    break;
                case 4:
                    nexttile = 1;
                    break;
            }
            spawnposition = new Vector3(spawnposition.x + 20, -15, 0);
        }
    }
}
