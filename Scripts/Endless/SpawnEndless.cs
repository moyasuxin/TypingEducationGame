using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEndless : MonoBehaviour
{
    public static SpawnEndless spawnerEndless {private set;get;}
    public GameObject zombiePrefab;
    public float minSpawnDelay, maxSpawnDelay;
    public GameObject spawnerMusic;
    public Detectors detector;
    Coroutine co;

    private bool spawnerhe = true;

    //define integer
    float spawnDelay; 
    float timer;
    void Awake() 
    {
        spawnerEndless = this;
    }

    void Start() 
    {
        spawnerhe = true;
        co = StartCoroutine(SpawnerOverTimeEndless());
    }
    

    void OnDestroy()
    {
        spawnerEndless = null;
    }

    IEnumerator SpawnerOverTimeEndless()
    {
        while (spawnerhe == true)
        {
            spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            SpawnZombie();
            SpawnMusic();
        }
        yield return null; 
    }
    public void SpawnZombie()
    {
        GameObject go = Instantiate(zombiePrefab, transform.position, transform.rotation);
        Detectors.detector.allEnemies.Add(go);
    }

    public void StopSpawn()
    {
        Debug.Log("stopspawning is true");
        StopCoroutine(co);
    }
    void SpawnMusic()
    {
        GameObject newMusic = Instantiate(spawnerMusic);
    }
}
