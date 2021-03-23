using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJosBizarreCoding : MonoBehaviour
{

    [SerializeField] private Transform GlobalLocation;
    public GameObject Obj_bank;
    public GameObject Obj_buBall;
    public GameObject Obj_groceries;
    public GameObject Obj_vistGF;
    public GameObject Obj_WFH;
    public GameObject Obj_bed;

    public GameObject Check_Obj_bank;

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
        if (Obj_bank)
        {
            Debug.Log("Colide");

            Check_Obj_bank.transform.position = GlobalLocation.transform.position;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (Obj_bank)
        {
            Debug.Log("No");
            Check_Obj_bank.transform.position = Obj_bank.transform.position;
        }
    }
}
