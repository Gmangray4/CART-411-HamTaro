using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckList : MonoBehaviour
{

    public GameObject ActiveTask;
    LightingManager CheckTask;

    public GameObject bankText;
    public GameObject buyBallText;
    public GameObject groceriesText;
    public GameObject vistGFText;
    public GameObject goHomeText;

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
        ////////////////////////////////////////////////////////////////////////////
        
        ///Buy Ball

        if (CheckTask.buyBall == false && CheckTask.ActivebuyBall == false)
        {
            buyBallText.GetComponent<Text>().color = new Color32(128, 128, 128, 255);
        }
        if (CheckTask.buyBall == false && CheckTask.ActivebuyBall == true)
        {
            buyBallText.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        }
        if (CheckTask.buyBall == true)
        {
            buyBallText.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
        }

        ///////////////////////////////////////////////////////////////
        

        if (CheckTask.groceries == false && CheckTask.Activegroceries == false)
        {
            groceriesText.GetComponent<Text>().color = new Color32(128, 128, 128, 255);
        }
        if (CheckTask.groceries == false && CheckTask.Activegroceries == true)
        {
            groceriesText.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        }
        if (CheckTask.groceries == true)
        {
            groceriesText.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
        }

        ///////////////////////////////////////////////////////////////
        ///

        if (CheckTask.vistGF == false && CheckTask.ActivevistGF == false)
        {
            vistGFText.GetComponent<Text>().color = new Color32(128, 128, 128, 255);
        }
        if (CheckTask.vistGF == false && CheckTask.ActivevistGF == true)
        {
            vistGFText.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        }
        if (CheckTask.vistGF == true)
        {
            vistGFText.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
        }

        //////////////////////////////////////
        ///

        if (CheckTask.bed == false && CheckTask.Activebed == false)
        {
            goHomeText.GetComponent<Text>().color = new Color32(128, 128, 128, 255);
        }
        if (CheckTask.bed == false && CheckTask.Activebed == true)
        {
            goHomeText.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        }
        if (CheckTask.bed == true)
        {
            goHomeText.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
        }

    }

}
