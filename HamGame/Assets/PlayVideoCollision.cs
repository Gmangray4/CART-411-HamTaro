using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoCollision : MonoBehaviour
{
    public GameObject Player;
    public UnityEngine.Video.VideoPlayer Video;

    // Start is called before the first frame update
    void Start()
    {
        Video.Pause();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Video.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Video.Pause();
        }
    }
}
