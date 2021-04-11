using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCollisingPlayer : MonoBehaviour
{


    public GameObject Golble;
    public GameObject player;
    public GameObject ball;
    public GameObject TextImage;
    EnterBall InBall;
    bool playerInBall;
    bool ContactMade;

    // Start is called before the first frame update
    void Start()
    {
        InBall = ball.GetComponent<EnterBall>();
        ContactMade = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerInBall = InBall.inVehicle;
    }

    void Update()
    {
        if (ContactMade == true)
        {
            TextImage.SetActive(true);
            StartCoroutine(timer());
            player.GetComponent<ThirdPersonController>().enabled = false;
            player.GetComponent<ThirdPersonCamera>().enabled = false;
            ContactMade = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Sends a cube to global to let it know the user is at the bank
        if (other.gameObject.tag == "Player" && playerInBall == false)
        {
            ContactMade = true;
        }
    }

    IEnumerator timer()
    {

        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(5.0f);
        TextImage.SetActive(false);
        Golble.GetComponent<LightingManager>().InteractionNPC = true;
    }

}
