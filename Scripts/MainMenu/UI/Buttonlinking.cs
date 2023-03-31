using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonlinking : MonoBehaviour
{
    public GameObject LoginUI;
    public GameObject RegisterUI;
    
    public void OpenLogin()
    {
        if(LoginUI.activeInHierarchy == true)
        {
            LoginUI.SetActive(false);
            RegisterUI.SetActive(true);
        }
        else
        {
            LoginUI.SetActive(true);
            RegisterUI.SetActive(false);
        }
    }
    public void OpenRegister()
    {
        if(RegisterUI.activeInHierarchy == true)
        {
            RegisterUI.SetActive(false);
            LoginUI.SetActive(true);
        }
        else
        {
            RegisterUI.SetActive(true);
            LoginUI.SetActive(false);
        }
    }
    
}
