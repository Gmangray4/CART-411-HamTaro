using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisingCopWithPlayer : MonoBehaviour
{
    public GameObject Golble;
    public GameObject player;
    public GameObject TextImage;
    private bool skip;
    bool interaction;

    bool ContactMade;

    // Start is called before the first frame update
    void Start()
    {
        ContactMade = false;
        skip = false;
        interaction = false;
    }

    // Update is called once per frame


    void Update()
    {
        if (ContactMade == true)
        {
            TextImage.SetActive(true);
            StartCoroutine(timer());
            player.GetComponent<ThirdPersonController>().enabled = false;
            player.GetComponent<ThirdPersonCamera>().enabled = false;
            ContactMade = false;
            interaction = true;

        }
        if (Input.GetKeyDown(KeyCode.Space) && interaction == true)
        {
            skip = true;
            TextImage.SetActive(false);
            Golble.GetComponent<LightingManager>().InteractionCop = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Sends a cube to global to let it know the user is at the bank
        if (other.gameObject.tag == "Player")
        {
            ContactMade = true;
        }
    }

    IEnumerator timer()
    {
        Debug.Log("Your enter Coroutine at" + Time.time);
        yield return new WaitForSeconds(5.0f);
        if (skip == false){
            TextImage.SetActive(false);
            Golble.GetComponent<LightingManager>().InteractionCop = true;
        }
        
    }
}
