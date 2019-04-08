using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickScript : MonoBehaviour
{
    //public AudioSource impactSound;
    public GameObject brickParticle;
    public GameObject powerUp;
    public int brickHealth = 1;
    public int chanceToDrop = 50;
    

    void OnCollisionEnter(Collision other)
    {

        Instantiate(brickParticle, transform.position, Quaternion.identity);
        brickHealth--;
        int randomChance = Random.Range(1, 100);
        if (randomChance < chanceToDrop)
        {
            
            Instantiate(powerUp, transform.position, transform.rotation);
            //drop a powerup
        }
        if (brickHealth == 0)
        {
            GM.instance.DestroyBrick();
            gameObject.SetActive(false);
        }
        
        
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
