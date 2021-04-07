using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBall : MonoBehaviour
{
    public bool inVehicle = false;
    BallController BallControls;
    public GameObject guiObj;
    GameObject player;
    public GameObject Ball;

    public Camera camplayer;
    public Camera camCar;

    void Start()
    {
        BallControls = GetComponent<BallController>();
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
                BallControls.enabled = true;
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
    void FixedUpdate()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            BallControls.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
            camplayer.enabled = true;
            camCar.enabled = false;  
            player.transform.position = new Vector3(Ball.transform.position.x, Ball.transform.position.y + 5, Ball.transform.position.z);

        }
    }
}
