using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopSpawner_Big : MonoBehaviour
{
    public PlayerController player;
    public GameObject bigHoopPrefabs;
    private Vector2 bigSpawnLocation;


    public float spawnTimeMin = 3f;
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
        bigSpawnLocation = new Vector2(player.transform.position.x + 18f, 0f);
        timeAfterSpawn += Time.deltaTime;
        spawnRate = Random.Range(spawnTimeMin, spawnTimeMax);


        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bigHoop = Instantiate(bigHoopPrefabs, bigSpawnLocation, transform.rotation);
        }
    }
}
