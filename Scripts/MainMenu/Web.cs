using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Web : MonoBehaviour
{
    public Register register;
    public Login login;
    void Start()
    {
        //StartCoroutine(GetRequest("http://localhost/UnityBackend/GetUser.php"));
        //login page
        //StartCoroutine(Login("Admin", "admin"));
        //StartCoroutine(Register("Admin1", "admin1", "yuhengjeff@gmail.com", 01151505752));
        
    }

    /*
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }*/
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("UserName", username);
        form.AddField("UserPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                if (responseText.Contains("Login Success."))
                {
                    login.ShowSuccessMessage();
                }
                else if (responseText.Contains("Wrong Credentials."))
                {
                    login.ShowErrorMessage();
                }
                else
                {
                    login.ShowErrorMessage1();
                }
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    public IEnumerator Register(string username, string password, string email, int phone, GameObject successObject, GameObject errorObject)
    {
        WWWForm form = new WWWForm();
        form.AddField("UserName", username);
        form.AddField("UserPassword", password);
        form.AddField("UserEmail", email);
        form.AddField("UserPhone", phone);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                if (responseText.Contains("Username is already taken."))
                {
                    register.ShowErrorMessage();
                }
                else if (responseText.Contains("New record created successfully"))
                {
                    register.ShowSuccessMessage();
                }
                else
                {
                    Debug.Log(responseText);
                    register.ShowErrorMessage();
                }
            }
        }
    }
}