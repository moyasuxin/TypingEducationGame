using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardButton : MonoBehaviour
{
    public GameObject TopLeader;
    
    public void OnClickButton()
    {
        if(TopLeader.activeInHierarchy == true)
        {
            TopLeader.SetActive(false);
        }
        else
        {
            TopLeader.SetActive(true);
        }
    }
}
