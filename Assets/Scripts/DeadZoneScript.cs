using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("hello");
    }
    private void OnTriggerEnter(Collider col)
    {
        print("ball hit deadzone");
        if (col.gameObject.name.Contains("Ball"))
        {
            //col.gameObject.SetActive(false);
            Destroy(col.gameObject, 0f);
        }
        GM.instance.LoseLife();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
