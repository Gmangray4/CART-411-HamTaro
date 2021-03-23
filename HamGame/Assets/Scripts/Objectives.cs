using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{

    private bool bank;
    private bool buyBall;
    private bool groceries;
    private bool vistGF;
    private bool WFH;
    private bool bed;

    
    public GameObject time;
    private float hour;
   

    // Start is called before the first frame update
    void Start()
    {
        bank = false;
        buyBall = false;
        groceries = false;
        vistGF = false;
        WFH = false;
        bed = false;

  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
