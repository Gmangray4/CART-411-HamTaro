using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTask : MonoBehaviour
{
    public GameObject guiObj;
    public GameObject TextImage;
    public GameObject player;
    public bool interact;
    public bool SpaceKeyCoolDown;
    private bool enter = false;
    public bool InteractionComplete;
    private bool skip;

    void Start()
    {
    
        player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);
        SpaceKeyCoolDown = false;
        skip = false;

    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && InteractionComplete == false && interact == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.Space) && SpaceKeyCoolDown == false)
            {
                SpaceKeyCoolDown = true;
                interact = true;
                StartCoroutine(timer2());
                guiObj.SetActive(false);
                TextImage.SetActive(true);
                player.GetComponent<ThirdPersonController>().enabled = false;
                player.GetComponent<ThirdPersonCamera>().enabled = false;
                StartCoroutine(timer());
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            guiObj.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && SpaceKeyCoolDown == false && interact == true)
        {
            skip = true;
            TextImage.SetActive(false);
            InteractionComplete = true;
            guiObj.SetActive(false);
            player.GetComponent<ThirdPersonController>().enabled = true;
            player.GetComponent<ThirdPersonCamera>().enabled = true;
        }
    }


    IEnumerator timer()
    {
    
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(5.0f);
        if(skip == false)
        {
            TextImage.SetActive(false);
            InteractionComplete = true;
            guiObj.SetActive(false);
            player.GetComponent<ThirdPersonController>().enabled = true;
            player.GetComponent<ThirdPersonCamera>().enabled = true;
        }
       
    }

    IEnumerator timer2()
    {

        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(1.0f);
        SpaceKeyCoolDown = false;
    }
}
