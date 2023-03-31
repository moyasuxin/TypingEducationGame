using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Typer : MonoBehaviour
{
public static Typer typer {private set;get;}

    public WordBank wordBank;

    public Text wordOutput = null;
    public Detectors detect;
    public EnemyLeftText enemyLeft;
    public GameManager gameManager;


    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    [HideInInspector]
    public bool gameRunning;    //Check if the game has not reach game over/game win then allow the type to check input
                                //(Need to on game over set this gameRunning to false as well)
    
    private void Awake()
    {
        typer = this;
    }
    private void OnDestroy() 
    {
        typer = null;
    }
    private void Start()
    {
        gameRunning = true;
        SetCurrentWord();
    }

    public void SetCurrentWordExternal()
    {
        SetCurrentWord();
    }
    void SetCurrentWord()
    {
        if(!gameManager.EndlessMode) //Checks that endless mode is false
        {
            currentWord = wordBank.GetWord();
        }
        else
        {
            currentWord = wordBank.GetWordEndless();
        }
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(!gameRunning) return;

        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if(IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                Player.player.playerAnim.SetInteger("Int1", 2 );

                if(Detectors.detector.allEnemies.Count > 0)
                {
                    detect.DestroyEnemy();
                    enemyLeft.AddKill();
                    if(!gameManager.EndlessSpawn)
                    {
                        if(enemyLeft.kills == Spawner.spawner.spawnLimit)
                        {
                            gameRunning = false;    //This should stop the typer from running once you hit enough kills
                                                //Add the code to on the game win screen here as well
                                                //Then when the user press restart can restart game by SceneLoading (But need to see if any issues appear if doing the online leaderboard)
                            gameManager.WinGame();

                        }
                        else
                        {
                            SetCurrentWord();
                        }
                    }
                    else
                    {
                        SetCurrentWord();
                    }
                }
                else
                {
                    SetCurrentWord(); //So that when you shoot when there is no enemy out, you will just play the animation and still have a new word appear
                }
                  
            }
        }
        else
        {
            //print("else is working");
            Output.outputs.outputAnim.SetTrigger("TriWrong");
            //Output.output.outputAnim.SetInteger("Int3", 1);
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.ToLower().IndexOf(letter.ToLower()) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }
}
