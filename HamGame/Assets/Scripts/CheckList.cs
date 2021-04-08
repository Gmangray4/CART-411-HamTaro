using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckList : MonoBehaviour
{

    public GameObject ActiveTask;
    LightingManager CheckTask;

    public GameObject bankText;

    // Start is called before the first frame update
    void Start()
    {
        CheckTask = ActiveTask.GetComponent<LightingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckTask.bank == false && CheckTask.Activebank == true)
        {
            bankText.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        }
        if (CheckTask.bank == true)
        {
            bankText.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
        }
    }

}
