using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Typer typer;
    public static Player player {private set;get;}
    public Animator playerAnim;

    public AudioSource DestroyZombie;

    void Awake()
    {
        player = this;
    }

    void OnDestroy()
    {
        player = null;
    }

    // Start is called before the first frame update


    void Start()
    {
        typer = typer.GetComponent<Typer>();
        playerAnim = GetComponent<Animator>();
        DestroyZombie = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartBlasting()
    {
        DestroyZombie.Play();
    }

    void EndAnimation()
    {

        playerAnim.SetInteger("Int1", 1);
    }

}
