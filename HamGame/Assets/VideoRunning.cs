using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoRunning : MonoBehaviour
{

    GameObject Obj;

    VideoPlayer Vid;
    LightingManager Time;
    ThirdPersonController PlayerMovement; 
    public GameObject Gol;
    public GameObject Player;
    public GameObject MoveObj;
    public GameObject TeloportPonit;
    



    // Start is called before the first frame update
    void Start()
    {
        Obj = this.gameObject;
        Vid = GetComponent<VideoPlayer>();
        //Vid.enabled = true;
        Time = Gol.GetComponent<LightingManager>();

        PlayerMovement = Player.GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vid.enabled == true)
        {
            PlayerMovement.enabled = false;

        }
        Vid.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

  
    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        Time.TimeOfDay = Time.TimeOfDay + 1;
        PlayerMovement.enabled = true;
        Vid.enabled = false;
        player.Stop();
}

}
