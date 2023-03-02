using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public int a = 7;
    public int b = 8;
    public int c = 12;
    // Start is called before the first frame update
    void Start()
    {
        a = c;
        c = a;
        b = b + c;
        b = b + a;
        Debug.Log("b = " + b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
