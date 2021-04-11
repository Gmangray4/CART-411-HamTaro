using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureFlip : MonoBehaviour
{

    public GameObject Char;
    private float oldPosition = 0.0f;
    public Sprite left;
    public Sprite right;

    void Start()
    {
        oldPosition = Char.transform.position.x;
    }

    void FixedUpdate()
    {
       

        //Char.transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

        if (Char.transform.position.x > oldPosition) // he's looking right
        {
            //Char.transform.localRotation = Quaternion.Euler(0, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }

        if (Char.transform.position.x < oldPosition) // he's looking left
        {
           // Char.transform.localRotation = Quaternion.Euler(0, 180, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
        }

        oldPosition = Char.transform.position.x;
    }
}
