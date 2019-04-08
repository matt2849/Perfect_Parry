using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaddleControl : MonoBehaviour
{
    public float activeInterval = 1f;
    private float lastActiveTime = 0f;
    public float speed = 1f;
    int timeOut = 30;
    bool isOut = false;
    public float leftandRightEdge = 9;
    public AudioSource punchSound;
    // Vector3 playerPos = new Vector3()


    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        float pos = transform.position.x;
        float xAxis = (Input.GetAxis("Horizontal") * speed);
        
        if(-9 < pos && pos < 9)
        {
            transform.Translate(xAxis, 0, 0);
        }
        else if(pos > 9 && xAxis < 0)
        {
            transform.Translate(xAxis, 0, 0);
        }
        else if(pos < -9 && xAxis > 0)
        {
            transform.Translate(xAxis, 0, 0);
        }
        bool triggerDown = Input.GetButton("Fire1");
        if (isOut == false && triggerDown && lastActiveTime + activeInterval < Time.time)
        {

                timeOut = 30;
                lastActiveTime = Time.time;
            
                
            transform.Translate(0, 0, -1);
            print("frame is active");
            isOut = true;
            punchSound.Play();
            
        }
        timeOut--;
        if (timeOut == 0 && isOut == true)
        {
            isOut = false;
            transform.Translate(0, 0, 1);
        }
        
    }
}
