﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoRunning : MonoBehaviour
{

    GameObject Obj;
    VideoPlayer Vid;

    // Start is called before the first frame update
    void Start()
    {
        Obj = this.gameObject;
        Vid = GetComponent<VideoPlayer>();

        Vid.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vid.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

  
    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        player.Stop();
        Vid.enabled = false;
    }

}
