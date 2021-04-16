using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayOrExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName: "Scenes/Title");
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SceneManager.LoadScene(sceneName: "Scenes/Day1");
        }
    }
}
