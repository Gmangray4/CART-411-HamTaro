using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopSeekPonit : MonoBehaviour
{

    public GameObject Player;
    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Player.tag == "Player")
        {
            this.gameObject.transform.position = Player.transform.position;
        }
        if (Player.tag == "Ball")
        {
            this.gameObject.transform.position = Ball.transform.position;
        }
    }
}
