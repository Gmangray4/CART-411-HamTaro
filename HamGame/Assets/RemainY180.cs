using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainY180 : MonoBehaviour
{

    public GameObject plane;
    // Start is called before the first frame update
  
    
    Transform t;
    public float fixedRotation = 180;

    void Start()
    {
        t = transform;
    }

    void Update()
    {
        plane.transform.eulerAngles = new Vector3(t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
    }
}
