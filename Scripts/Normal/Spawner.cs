using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner {private set;get;}

    public float minSpawnDelay, maxSpawnDelay;
    public GameObject zombiePrefab;
    public GameObject spawnerMusic;
    public float spawnTime;
    public int spawnLimit;

    float spawnDelay; 


    private int enemies;


    private void Awake() 
    {
        spawner = this;
    }
    
    void OnDestroy()
    {
        spawner = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemies = 0;
        StartCoroutine("SpawnerOverTime");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnZombie()
    {
        GameObject go = Instantiate(zombiePrefab, transform.position, transform.rotation);
        Detectors.detector.allEnemies.Add(go);
        

        ++enemies;
    }

    IEnumerator SpawnerOverTime()
    {
        while (enemies < spawnLimit)
        {
            spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            SpawnZombie();
            SpawnMusic();
        }
        yield return null; 
    }

    public void StopSpawn()
    {
        StopCoroutine("SpawnerOverTime");
    }

    void SpawnMusic()
    {
        GameObject newMusic = Instantiate(spawnerMusic);
    }
    
}
