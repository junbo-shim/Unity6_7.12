using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopSpawner_Small : MonoBehaviour
{
    public PlayerController player;
    public GameObject smallHoopPrefabs;
    private Vector2 smallSpawnLocation;


    public float spawnTimeMin = 10f;
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
        smallSpawnLocation = new Vector2(player.transform.position.x + 18f, -0.2f);
        timeAfterSpawn += Time.deltaTime;
        spawnRate = Random.Range(spawnTimeMin, spawnTimeMax);


        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject smallHoop = Instantiate(smallHoopPrefabs, smallSpawnLocation, transform.rotation);
        }
    }
}
