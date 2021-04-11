using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTask : MonoBehaviour
{
    public GameObject guiObj;
    public GameObject TextImage;
    public GameObject player;
    public bool interact;
    private bool enter = false;
    public bool InteractionComplete;

    void Start()
    {
    
        player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);

    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && InteractionComplete == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
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


    IEnumerator timer()
    {
    
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(5.0f);
        TextImage.SetActive(false);
        InteractionComplete = true;
        player.GetComponent<ThirdPersonController>().enabled = true;
        player.GetComponent<ThirdPersonCamera>().enabled = true;
    }
}
