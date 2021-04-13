using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBall : MonoBehaviour
{
    public bool inVehicle = false;
    BallController BallControls;
    public GameObject guiObj;
    GameObject player;
    public GameObject playerSprite;
    public GameObject Ball;

    public Camera camplayer;
    public Camera camCar;

    bool enterCoolDown;

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
            if (Input.GetKey(KeyCode.E) && enterCoolDown == false)
            {
                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                BallControls.enabled = true;
                player.SetActive(false);
                playerSprite.SetActive(false);
                inVehicle = true;
                camCar.enabled = true;
                camplayer.enabled = false;
                enterCoolDown = true;
                StartCoroutine(timer());
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
        if (inVehicle == true && Input.GetKey(KeyCode.E) && enterCoolDown == false)
        {
            BallControls.enabled = false;
            player.SetActive(true);
            playerSprite.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
            camplayer.enabled = true;
            camCar.enabled = false;  
            player.transform.position = new Vector3(Ball.transform.position.x, Ball.transform.position.y + 5, Ball.transform.position.z);
            playerSprite.transform.position = player.transform.position;
            enterCoolDown = true;
            StartCoroutine(timer());
        }
    }

    IEnumerator timer()
    {

        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(1.0f);
        enterCoolDown = false;
    }
}
