using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpawner : MonoBehaviour
{
    public PlayerController player;
    public GameObject potPrefabs;
    private Vector2 spawnLocation;


    public float spawnTimeMin = 8f;
    public float spawnTimeMax = 30f;
    private float spawnRate;
    private float timeAfterSpawn;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnLocation = new Vector2(player.transform.position.x + 15f, -2.6f);
        timeAfterSpawn += Time.deltaTime;
        spawnRate = Random.Range(spawnTimeMin, spawnTimeMax);

        if(timeAfterSpawn >= spawnRate) 
        {
            timeAfterSpawn = 0f;
            GameObject pots = Instantiate(potPrefabs, spawnLocation, transform.rotation);
        }
    }
}
