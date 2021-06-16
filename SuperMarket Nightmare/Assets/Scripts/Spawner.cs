using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float speed = 10.0f;
    public float spawnTime;
    private Rigidbody2D rb;
    private Vector2 bounds;
    private float karenSpawn = 60;
    public float currentTime = 0;
    private bool spawned = false;

    [SerializeField]
    private GameObject[] prefabs;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if((currentTime >= karenSpawn) && (spawned == false)){
             GameObject enemyObj = Instantiate(prefabs[2], new Vector3(transform.position.x - 3.0f, transform.position.y, 0), Quaternion.identity);
             spawned = true;
         }
        Spawn();
    }

    void Spawn(){
        if (Time.time> spawnTime)
             {
                spawnTime += 5;
                int r = Random.Range(0,2);
                GameObject enemyObj = Instantiate(prefabs[r], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
             }
    }
        
}