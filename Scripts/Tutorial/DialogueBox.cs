using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    // picture of keyboard in here
    public GameObject Keyboard;
    public GameObject Keyboard1;
    public GameObject Keyboard2;

    // picture of game mechanic here
    public GameObject Health;
    public GameObject Healthbar;
    public GameObject Zombie;
    public GameObject Zombie2;
    public GameObject Bite;
    public GameObject Maingame;
    public GameObject Maingame1;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            
            if  (textComponent.text == lines[index])
            {
                NextLine();
                //picture show and close followed by which array is doing now.
                if(lines[3] == lines[index])
                {
                    Keyboard.SetActive(true);
                }
                else if(lines[5] == lines[index])
                {
                    Keyboard.SetActive(false);
                    Keyboard1.SetActive(true);
                }
                else if(lines[7] == lines[index])
                {
                    Keyboard1.SetActive(false);
                }
                else if(lines[10] == lines[index])
                {
                    Keyboard2.SetActive(true);
                }
                else if(lines[12] == lines[index])
                {
                    Keyboard2.SetActive(false);
                }
                else if(lines[16] == lines[index])
                {
                    Health.SetActive(true);
                }
                else if(lines[17] == lines[index])
                {
                    Health.SetActive(false);
                    Healthbar.SetActive(true);
                }
                else if(lines[17] == lines[index])
                {
                    Health.SetActive(false);
                    Healthbar.SetActive(true);
                }
                else if(lines[19] == lines[index])
                {
                    Healthbar.SetActive(false);
                    Zombie.SetActive(true);
                }
                else if(lines[20] == lines[index])
                {
                    Zombie.SetActive(false);
                    Zombie2.SetActive(true);
                }
                else if(lines[21] == lines[index])
                {
                    Zombie2.SetActive(false);
                    Bite.SetActive(true);
                }
                else if(lines[22] == lines[index])
                {
                    Bite.SetActive(false);
                }
                else if(lines[26] == lines[index])
                {
                    Maingame.SetActive(true);
                }
                else if(lines[27] == lines[index])
                {
                    Maingame.SetActive(false);
                    Maingame1.SetActive(true);
                }
                else if(lines[28] == lines[index])
                {
                    Maingame1.SetActive(false);
                }
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }



    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            ExitLevel();
            gameObject.SetActive(false);
        }
    }

    void ExitLevel()
    {
        print("its work exit");
        SceneManager.LoadScene("MainMenu");
    }

}

