using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{  
    Rigidbody2D rb;

    public float jumpForce;
    public GameObject loseScreenUI;
    public int score, hiScore;
    string HISCORE = "HISCORE";
    public Text scoreUI, hiScoreUI;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        // load game
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        // GetMouseButton, Fungsi ini mengembalikan nilai true selama
        // tombol mouse yang ditentukan sedang ditekan.
        
        // GetMouseButtonDown, Fungsi ini mengembalikan nilai true hanya pada frame
        // ketika tombol mouse yang ditentukan ditekan untuk pertama kalinya.
        
        // GetMouseButtonUp, Fungsi ini mengembalikan nilai true hanya pada frame
        // ketika tombol mouse yang ditentukan dilepaskan.
        if (Input.GetMouseButtonDown(0))
        {
			AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void PlayerLose()
    {
		AudioManager.singleton.PlaySound(1);
        if (score > hiScore)
        {
            hiScore = score;
            // save game
            PlayerPrefs.SetInt(HISCORE, hiScore);
        }
        hiScoreUI.text = "HiScore: " + hiScore.ToString();
        loseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void AddScore()
    {
        // play sfx
		AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "score: " + score.ToString();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            // Bakalan mati
            PlayerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score"))
        {
            AddScore();
        }
    }
}