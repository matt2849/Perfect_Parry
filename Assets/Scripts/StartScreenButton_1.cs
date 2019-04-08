using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButton_1 : MonoBehaviour
{
    public AudioSource punchSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void playGame()
    {
        SceneManager.LoadScene("Scene_1");
    }
    public void onClick()
    {
        punchSound.Play();
        Invoke("playGame", 1.5f);
    }

}
