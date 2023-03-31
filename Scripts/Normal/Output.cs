using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
    public static Output outputs {private set;get;}
    public Animator outputAnim;

    void Awake()
    {
        outputs = this;
    }
    
    void OnDestroy()
    {
        outputs = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        outputAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
