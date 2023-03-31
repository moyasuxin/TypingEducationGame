using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    public static Bite bite{private set;get;}
    public Renderer biteRenderer;
    public Animator biteAnim;

    public AudioSource audioBite;
    // Start is called before the first frame update
    void Awake()
    {
        bite = this;
    }
    
    void OnDestroy()
    {
        bite = null;
    }
    void Start()
    {
        biteRenderer = GetComponent<Renderer>();
        biteAnim = GetComponent<Animator>();
        audioBite = GetComponent<AudioSource>();
        biteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BiteShow()
    {
        //print("biteshow function ok");
        biteRenderer.enabled = true;
        audioBite.Play();
        biteAnim.SetInteger("IntBite", 2);
    }

    void BiteEnd()
    {
        biteAnim.SetInteger("IntBite", 1);
        biteRenderer.enabled = false;
    }
}
