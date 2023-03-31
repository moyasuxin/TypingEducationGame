using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public static Login Instance {private set;get;}
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public Button LoginButton;
    public GameObject successObject;
    public GameObject errorObject;
    public GameObject errorObject1;
    
    public float displayTime = 2f;
    void Awake() 
    {
        Instance = this;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    //Use this for initialization
    void Start()
    {
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Mainweb.main.web.Login(UsernameInput.text, PasswordInput.text)); 
        });
    }

    public void ShowSuccessMessage()
    {
        successObject.SetActive(true);
        StartCoroutine(HideMessage(successObject));
    }

    public void ShowErrorMessage()
    {
        errorObject.SetActive(true);
        StartCoroutine(HideMessage(errorObject));
    }
    public void ShowErrorMessage1()
    {
        errorObject1.SetActive(true);
        StartCoroutine(HideMessage(errorObject1));
    }
    IEnumerator HideMessage(GameObject message)
    {
        yield return new WaitForSeconds(displayTime);
        message.SetActive(false);
    }
}
