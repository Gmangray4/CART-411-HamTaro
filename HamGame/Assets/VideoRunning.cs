﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoRunning : MonoBehaviour
{

    GameObject Obj;

    VideoPlayer Vid;
    LightingManager Time;
    ThirdPersonController PlayerMovement;
    RawImage vidDisplay;
    public GameObject Gol;
    public GameObject Player;
    public GameObject VidUI;
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
        vidDisplay = VidUI.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vid.enabled == true)
        {
            PlayerMovement.enabled = false;
            vidDisplay.enabled = true;
        }
        Vid.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

  
    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        Time.TimeOfDay = Time.TimeOfDay + 1;
        PlayerMovement.enabled = true;
        vidDisplay.enabled = false;
        Vid.enabled = false;
        player.Stop();
}

}
