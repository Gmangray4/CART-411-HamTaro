using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToControls : MonoBehaviour
{
    public GameObject controlsImg;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        controlsImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If press ENTER, make the Controls image show up
        if (Input.GetKeyDown(KeyCode.Return))
        {
            controlsImg.SetActive(true);
            count++;
        }

        // If press SPACE, when the Controls image is up, the scene goes to the Intro scene
        if (controlsImg == true && count == 1 &&  Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName: "Scenes/Intro");
        }
    }
}
