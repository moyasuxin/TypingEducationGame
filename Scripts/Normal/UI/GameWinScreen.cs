using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameWinScreen : MonoBehaviour
{
    public float fadeTimeWin = 1f;
    public CanvasGroup canvasGroupWin;
    public RectTransform rectTransformWin;
    
    public AudioSource youWinMusic;

    public ParticleSystem fireworks;

    public void GameWinFadeIn()
    {
        //fade panel
        canvasGroupWin.alpha = 0f;
        rectTransformWin.transform.localPosition = new Vector3 (0f, -1000f, 0f);
        rectTransformWin.DOAnchorPos(new Vector2(0f, 0f), fadeTimeWin, false).SetEase(Ease.OutElastic);
        canvasGroupWin.DOFade(1, fadeTimeWin);
    }

    public void GameWinFadeOut()
    {
        canvasGroupWin.alpha = 1f;
        rectTransformWin.transform.localPosition = new Vector3 (0f, 0f, 0f);
        rectTransformWin.DOAnchorPos(new Vector2(0f, -1000f), fadeTimeWin, false).SetEase(Ease.InOutQuint);
        canvasGroupWin.DOFade(1, fadeTimeWin);
    }
    public void Setup()
    {
        GameWinFadeIn();
        gameObject.SetActive(true);
        youWinMusic.Play();
        fireworks.Play();
        //print("win is works");
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitButtonWin()
    {
        GameWinFadeOut();
        StartCoroutine(WaitBeforeExit());
    }
    public void NextLevelButton()
    {
        GameWinFadeOut();
        StartCoroutine(WaitBeforeNext());
    }
    private IEnumerator WaitBeforeExit()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
    private IEnumerator WaitBeforeNext()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level2");
    }
}
