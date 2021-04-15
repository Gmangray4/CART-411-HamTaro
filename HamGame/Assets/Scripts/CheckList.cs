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

    Color32 ColorActive;
    Color32 ColorNotActive;
    Color32 ColorDone;

    // Start is called before the first frame update
    void Start()
    {
        CheckTask = ActiveTask.GetComponent<LightingManager>();

        ColorActive = new Color32(177, 187, 63, 255);
        ColorNotActive = new Color32(220, 110, 110, 255);
        ColorDone = new Color32(195, 200, 196, 255);
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckTask.bank == false && CheckTask.Activebank == false)
        {
            bankText.GetComponent<Text>().color = ColorNotActive;
        }
        
        if (CheckTask.bank == false && CheckTask.Activebank == true)
        {
            bankText.GetComponent<Text>().color = ColorActive;
        }
        if (CheckTask.bank == true)
        {
            bankText.GetComponent<Text>().color = ColorDone;
        }
        ////////////////////////////////////////////////////////////////////////////
        
        ///Buy Ball

        if (CheckTask.buyBall == false && CheckTask.ActivebuyBall == false)
        {
            buyBallText.GetComponent<Text>().color = ColorNotActive;
        }
        if (CheckTask.buyBall == false && CheckTask.ActivebuyBall == true)
        {
            buyBallText.GetComponent<Text>().color = ColorActive;
        }
        if (CheckTask.buyBall == true)
        {
            buyBallText.GetComponent<Text>().color = ColorDone;
        }

        ///////////////////////////////////////////////////////////////
        

        if (CheckTask.groceries == false && CheckTask.Activegroceries == false)
        {
            groceriesText.GetComponent<Text>().color = ColorNotActive;
        }
        if (CheckTask.groceries == false && CheckTask.Activegroceries == true)
        {
            groceriesText.GetComponent<Text>().color = ColorActive;
        }
        if (CheckTask.groceries == true)
        {
            groceriesText.GetComponent<Text>().color = ColorDone;
        }

        ///////////////////////////////////////////////////////////////
        ///

        if (CheckTask.vistGF == false && CheckTask.ActivevistGF == false)
        {
            vistGFText.GetComponent<Text>().color = ColorNotActive;
        }
        if (CheckTask.vistGF == false && CheckTask.ActivevistGF == true)
        {
            vistGFText.GetComponent<Text>().color = ColorActive;
        }
        if (CheckTask.vistGF == true)
        {
            vistGFText.GetComponent<Text>().color = ColorDone;
        }

        //////////////////////////////////////
        ///

        if (CheckTask.bed == false && CheckTask.Activebed == false)
        {
            goHomeText.GetComponent<Text>().color = ColorNotActive;
        }
        if (CheckTask.bed == false && CheckTask.Activebed == true)
        {
            goHomeText.GetComponent<Text>().color = ColorActive;
        }
        if (CheckTask.bed == true)
        {
            goHomeText.GetComponent<Text>().color = ColorDone;
        }

    }

}
