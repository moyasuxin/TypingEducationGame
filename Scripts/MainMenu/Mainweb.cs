using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainweb : MonoBehaviour
{
    public static Mainweb main; 
    public Web web;
    // Start is called before the first frame update
    void Start()
    {
        main = this;
        web = GetComponent<Web>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
