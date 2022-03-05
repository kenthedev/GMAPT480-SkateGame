using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float JumpForce;

    public bool isgrounded;

    public bool isalive = true;

    public float Score;

    public Text Scoretext;
    public Text Healthtext;

    public float health;
    public Obstacle obstacle;

    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponent<Obstacle>();
        health = obstacle.GetHealth();
        Healthtext.text = $"Lives: {health}";
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

        if(isalive)
        {
            Score += Time.deltaTime + 0.00001f;
            Scoretext.text = "Score : " + Score.ToString("F");
        }

        health = obstacle.GetHealth();
        Healthtext.text = $"Lives: {health}";
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
        if (collision.gameObject.CompareTag("spike"))
        {
            isalive = false;
            Time.timeScale = 0f;
        }
    }

    public void Jumpingtheguy()
    {
        if (isgrounded == true)
        {
            RB.AddForce(Vector2.up * JumpForce);
            isgrounded = false;
        }
    }
}
