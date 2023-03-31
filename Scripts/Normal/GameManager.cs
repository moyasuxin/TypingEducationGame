using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager {get; private set;}
    public Zombie zombie;
    public Spawner spawner;
    public SpawnEndless spawnerEndless;
    public GameOverScreen gameOverScreen;
    public GameWinScreen gameWinScreen;
    public AudioSource bgsounds;
    public AudioSource endsounds;
    public AudioSource winsounds;

    public string username;
    public string password;

    public float gameSpeed 
    {
        get; 
        private set;
    }
    public float initialGameSpeed; 
    public float gamespeedincrement;

    private float speedlimit = 20;


    //bool music
    public bool bgsong = true;
    public bool endsong = false; //Don't actually need the '= false'. Bool always start as false. Only if u want force it to true then need '= true'
    public bool winsong = false;

    //bool gamemode
    public bool EndlessMode;
    public bool EndlessSpawn;

    void Awake() 
    {
        if (gameManager != null) 
        {
            DestroyImmediate(gameObject);
        } 
        else
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void OnDestroy()
    {
        if (gameManager == this) 
        {
            gameManager = null;
        }
    }
    void Start()
    {
        zombie = zombie.GetComponent<Zombie>();
        NewGame();
    }

    void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }

    void Update()
    {
        if(gameSpeed < speedlimit)
        {
            gameSpeed += gamespeedincrement * Time.deltaTime;
        }
    }
    public void EndGame()
    {
        foreach(GameObject go in Detectors.detector.allEnemies)
        {
            Zombie zombie = go.GetComponent<Zombie>();
            zombie.alive = false;
        }
        if(EndlessSpawn == true)
        {
            spawnerEndless.StopSpawn();
        }
        else
        {
            spawner.StopSpawn();
        }
        EndMusic();
        gameOverScreen.Setup();
        Debug.Log("Game Over");
    }

    void StartMusic()
    {
        bgsong = true;
        endsong = false;
        winsong = false;
        bgsounds.Play();
    }

    void EndMusic()
    {
        if (bgsounds.isPlaying)
        {
            bgsong = false;
            bgsounds.Stop();
        }

        if (!endsounds.isPlaying && endsong == false)
        {
            endsounds.Play();
            endsong = true;
        }

    }


    public void WinGame()
    {
        foreach(GameObject go in Detectors.detector.allEnemies)
        {
            Zombie zombie = go.GetComponent<Zombie>();
            zombie.alive = false;
        }
        gameWinScreen.Setup();
        WinMusic();
        Debug.Log("Game Win");
    }

    void WinMusic()
    {
        if (bgsounds.isPlaying)
        {
            bgsong = false;
            bgsounds.Stop();
        }
        
        if (!winsounds.isPlaying && winsong == false)
        {
            winsounds.Play();
            winsong = true;
        }
    }
}
