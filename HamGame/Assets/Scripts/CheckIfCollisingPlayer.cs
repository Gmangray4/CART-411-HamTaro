using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCollisingPlayer : MonoBehaviour
{

    [SerializeField] private Transform GlobalLocation;
    public GameObject teleportPoint;
    public GameObject Check_Obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //Sends a cube to global to let it know the user is at the bank
        if (other.gameObject.tag == "Player")
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
