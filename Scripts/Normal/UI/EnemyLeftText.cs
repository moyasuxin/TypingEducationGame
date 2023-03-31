using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLeftText : MonoBehaviour
{
    public static EnemyLeftText ELT {private set;get;}

    public Text counterText;
    [HideInInspector]
    public int kills;

    private void Awake() 
    {
        ELT = this;
    }
    private void OnDestroy() 
    {
        ELT = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();
    }

    void ShowKills()
    {
        counterText.text = kills.ToString();
    }

    public void AddKill()
    {
        kills++;
    }
    
}
