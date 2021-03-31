using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainY180 : MonoBehaviour
{

    public GameObject plane;
   

    //public float fixedRotation = 180;
    
    public GameObject Obj;
    public float objY;

    void Update()
    {

        // plane.transform.position = new Vector3(100, 100, 100);
        plane.transform.position = new Vector3(Obj.transform.position.x, objY, Obj.transform.position.z);
    }
}
