using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float JumpForce;

    public bool isgrounded;

    public int MaxReps;
    public int Countingthereps = 0;

    public bool isalive = true;

    public float Score;

    public Text Scoretext;
    public Text Healthtext;

    public float scoremultiplier;

    public float health;
    public Obstacle obstacle;

    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Score = 0;
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponent<Obstacle>();
        health = obstacle.GetHealth();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isgrounded == true)
            {
                
                Jumpingtheguy();
            }
        }
        if(Countingthereps >= MaxReps)
        {
            egPauseManager.instance.PauseGame();
        }

        if(isalive)
        {
            Score += Time.deltaTime * scoremultiplier;
            Healthtext.text = "Current Multiplier " + scoremultiplier;
            Scoretext.text = "Score : " + Score.ToString("F");
        }

        health = obstacle.GetHealth();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isgrounded == false)
            {
                isgrounded = true;
            }

        }
        
    }


    public void Jumpingtheguy()
    {
        if (isgrounded == true)
        {
            AudioManager.instance.SFX[2].Play();
            RB.AddForce(Vector2.up * JumpForce);
            isgrounded = false;
            Countingthereps++;
        }
    }
}
