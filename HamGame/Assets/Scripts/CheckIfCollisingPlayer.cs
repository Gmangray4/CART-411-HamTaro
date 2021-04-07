﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCollisingPlayer : MonoBehaviour
{

    [SerializeField] private Transform GlobalLocation;
    public GameObject teleportPoint;
    public GameObject Check_Obj;

    public GameObject ball;
    EnterBall InBall;
    bool playerInBall;

    // Start is called before the first frame update
    void Start()
    {
        InBall = ball.GetComponent<EnterBall>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerInBall = InBall.inVehicle;
    }

    void OnTriggerStay(Collider other)
    {
        //Sends a cube to global to let it know the user is at the bank
        if (other.gameObject.tag == "Player" && playerInBall == false)
        {
            Check_Obj.transform.position = GlobalLocation.transform.position;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //Sends a cube away from global to let it know the user is away bank
        if (other.gameObject.tag == "Player")
        {
            Check_Obj.transform.position = teleportPoint.transform.position;
        }
    }
}
