using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainY180 : MonoBehaviour
{

    public GameObject plane;
   

    //public float fixedRotation = 180;
    
    public GameObject Obj;
    public float objY;
    private float zArea;
    public float zAdd;
    public float xAdd;

    void Update()
    {
        zArea = Obj.transform.position.z + 2;
        // plane.transform.position = new Vector3(100, 100, 100);
        plane.transform.position = new Vector3(Obj.transform.position.x + xAdd, objY, zArea + zAdd);
    }
}
