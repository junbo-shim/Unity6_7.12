using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpawner : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject potPrefabs;
    private GameObject[] pots;

    public int potCount = 2;


    public float spawnTimeMin = 2.2f;
    public float spawnTimeMax = 3f;
    private float spawnTime;
    private float lastSpawnTime;

    


    // Start is called before the first frame update
    void Start()
    {
        Vector2 potPosition = new Vector2(playerController.transform.position.x + 8f, -2.6f);

        pots = new GameObject[potCount];

        for(int i = 0; i < potCount; i++) 
        {
            pots[i] = Instantiate(potPrefabs, potPosition, Quaternion.identity);
        }

        spawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime) 
        {
            lastSpawnTime = Time.time;

            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

            



        }
    }
}
