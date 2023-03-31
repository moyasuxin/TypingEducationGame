using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;




public class GameOverScreen : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public void GameOverFadeIn()
    {
        //fade panel
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3 (0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

    public void GameOverFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3 (0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
    }

    public void Setup()
    {
        GameOverFadeIn();
        gameObject.SetActive(true);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void RestartButtonLevel1()
    {
        GameOverFadeOut();
        StartCoroutine(WaitBeforeShowLevel1());
    }
    public void RestartButtonLevel2()
    {
        GameOverFadeOut();
        StartCoroutine(WaitBeforeShowLevel2());
    }
    public void RestartButtonLevel3()
    {
        GameOverFadeOut();
        StartCoroutine(WaitBeforeShowLevel3());
    }
    public void RestartButtonLevelEnd()
    {
        GameOverFadeOut();
        StartCoroutine(WaitBeforeShowLevelEnd());
    }
    public void ExitButton()
    {
        GameOverFadeOut();
        StartCoroutine(WaitBeforeExit());
    }
        //SceneManager.LoadScene("MainMenu");

    private IEnumerator WaitBeforeExit()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
        print("mainmenu");
    }
    private IEnumerator WaitBeforeShowLevel1()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level1");
    }
    private IEnumerator WaitBeforeShowLevel2()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level2");
    }
    private IEnumerator WaitBeforeShowLevel3()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level3");
    }
    private IEnumerator WaitBeforeShowLevelEnd()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Endless");
    }
}

