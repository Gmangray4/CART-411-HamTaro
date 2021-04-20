using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToControls : MonoBehaviour
{
    //public GameObject controlsImg;
   // public int count;
 
    // Start is called before the first frame update
    void Start()
    {
        ///controlsImg.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {
  

        // If press SPACE, when the Controls image is up, the scene goes to the Intro scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName: "Scenes/Controls");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneName: "Scenes/Controls");
        }

    }

}
