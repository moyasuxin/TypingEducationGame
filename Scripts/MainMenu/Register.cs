using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Register : MonoBehaviour
{
    public static Register Instance {private set;get;}
    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public TMP_InputField EmailInput;
    public TMP_InputField PhoneInput;
    public Button RegisterButton;
    public GameObject successObject;
    public GameObject errorObject;

    public float displayTime = 2f;

    void Awake() 
    {
        Instance = this;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    void Start()
    {
        RegisterButton.onClick.AddListener(() =>
        {
            if (int.TryParse(PhoneInput.text, out int phone))
            {
                StartCoroutine(Mainweb.main.web.Register(
                    UsernameInput.text,
                    PasswordInput.text,
                    EmailInput.text,
                    phone,
                    successObject,
                    errorObject
                ));
            }
            else
            {
                ShowErrorMessage();
                Debug.LogError("Invalid phone number format.");
            }
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
    IEnumerator HideMessage(GameObject message)
    {
        yield return new WaitForSeconds(displayTime);
        message.SetActive(false);
    }
}
