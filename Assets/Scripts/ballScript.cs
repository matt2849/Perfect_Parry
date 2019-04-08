using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public float ballInitialVelocity = 600f;
    public AudioSource tonalImpact;
    private Rigidbody rb;
    private bool ballInPlay;
    GameObject ballPrefab;

    private GM _GM;
    //private brickScript _brickScript;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1.0f;
        rb = GetComponent<Rigidbody>();

        _GM = GameObject.Find("GM").GetComponent<GM>();
      // _brickScript = GameObject.Find("brickScript").GetComponent<brickScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        tonalImpact.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            _GM.lives++;
            print("EXTRA LIFE GAINED!");
            if(other.gameObject.name.Contains("powerUp"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
