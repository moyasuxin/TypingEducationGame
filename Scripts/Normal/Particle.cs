using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem zomexp;
    public Bite bite;

    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            bite.BiteShow();
            zomexp.Play();

            var healthComponent = GetComponent<Health>();
            if(healthComponent != null)
            {
                Debug.Log("health ok");
                healthComponent.TakeDamage(1);
            }
        }
    }
}
