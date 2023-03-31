using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHeart;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public AudioSource audioGameOver;

    public GameManager gameManager;

    void Start()
    {
        audioGameOver = GetComponent<AudioSource>();
    }

    void Update()
    {/*
        if(health > numOfHeart)
        {
            health = numOfHeart;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }*/
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
        if(health <= 0)
        {
            audioGameOver.Play();
            
            gameManager.EndGame();
        }
    }
}
