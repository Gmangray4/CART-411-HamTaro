using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    public GameObject Map;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Map.gameObject.SetActive(!Map.gameObject.activeSelf);
        }

        if (Map.gameObject.activeSelf == true)
        {

        }
        if (Map.gameObject.activeSelf == false)
        {

        }

    }
}
