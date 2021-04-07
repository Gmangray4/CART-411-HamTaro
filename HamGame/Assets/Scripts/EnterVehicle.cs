﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    CarUserControl vehicleScript;
    public GameObject guiObj;
    GameObject player;

    public Camera camplayer;
    public Camera camCar;

    void Start()
    {
        vehicleScript = GetComponent<CarUserControl>();
        player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);
        camplayer.enabled = true;
        camCar.enabled = false;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;              
                vehicleScript.enabled = true;
                player.SetActive(false);
                inVehicle = true;
                camCar.enabled = true;
                camplayer.enabled = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
            camplayer.enabled = true;
            camCar.enabled = false;
        }

    //if(inVehicle == true)
       // {
            
            //camCar.enabled = true;
      //  }
      //  if (inVehicle == false)
     //   {

        //   camplayer.enabled = true;
      //  }
    }
}