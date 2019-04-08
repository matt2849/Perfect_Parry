using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 21;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject ballPrefab; 
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;
   
    private GameObject clonePaddle;
    private GameObject cloneBall;
    public AudioSource punchSound;

    
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("LoadSceneA");
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        Setup();

    }
    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.localPosition = new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.localPosition = new Vector3(0.3f, 5, 1), Quaternion.identity);
        Instantiate(ballPrefab, transform.localPosition = new Vector3(0, 1, -1), Quaternion.identity);
    }

    void checkGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("nextScene", resetDelay);
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void nextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene("Start_Screen");
        }
        else
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        checkGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.localPosition = new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cloneBall = Instantiate(ballPrefab, transform.localPosition = new Vector3(0, 1, -1), Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        punchSound.Play();
        bricks--;
        
        checkGameOver();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
