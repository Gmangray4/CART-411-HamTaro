using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float Speed;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xSpeed, 0.0f, ySpeed);

        rb.AddForce (movement * Speed);


    }
}
