using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Zombie : MonoBehaviour
{
    public Typer typer;
    //public static Zombie zombie;
    public Animator zombieAnim;
    public float speed;
    public bool alive;

    private float speedgm;
    public bool EndlessMode;
    //set zombie movement speed over time when its endless mode


    void Awake()
    {
        //zombie = this;
    }

    void OnDestroy()
    {
        //zombie = null;
    }

    // Start is called before the first frame update


    void Start()
    {
        alive = true;
        typer = typer.GetComponent<Typer>();
        zombieAnim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        speedgm = GameManager.gameManager.gameSpeed;
        if(alive)
        {
            if(!EndlessMode)
            {
                transform.position = new Vector2(transform.position.x -speed * Time.deltaTime,
                transform.position.y);
            }
            else
            {
                transform.position += Vector3.left * speedgm * Time.deltaTime;
            }
        }
        //Debug.Log("zombie speed : " + speedgm);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Death"))
        {
            Detectors.detector.allEnemies.Remove(this.gameObject);
            EnemyLeftText.ELT.AddKill();
            if(EnemyLeftText.ELT.kills == Spawner.spawner.spawnLimit)
            {
                Typer.typer.gameRunning = false;    //This should stop the typer from running once you hit enough kills
                                            //Add the code to on the game win screen here as well
                                            //Then when the user press restart can restart game by SceneLoading (But need to see if any issues appear if doing the online leaderboard)
                Typer.typer.gameManager.WinGame();
            }
            else
            {
            Typer.typer.SetCurrentWordExternal();
            }
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("DeathEndless"))
        {
            Detectors.detector.allEnemies.Remove(this.gameObject);
            EnemyLeftText.ELT.AddKill();
            Typer.typer.SetCurrentWordExternal();
            Destroy(this.gameObject);
        }
    }
    void DestroyObject()
    {
        Detectors.detector.allEnemies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
