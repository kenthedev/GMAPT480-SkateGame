using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {
    

    PlayerMovement playerMovement;
    public float healthCount = 3f;
    public static Obstacle instance;
    [SerializeField]
    GameObject red;

    private void Start () {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
	}

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "spike") {
            // Kill the player
            Debug.Log("Player hit!");
            Destroy(collision.gameObject);
            gotHit();
            DecreaseHealth();
        }

    }

    void gotHit()
    {
        var color = red.GetComponent<Image>().color;
        color.a = 0.5f;

        red.GetComponent<Image>().color = color;
    }

    private void Update () {
	    

        if(red != null)
        {
            if(red.GetComponent<Image>().color.a > 0)
            {
                var color = red.GetComponent<Image>().color;
                color.a -= 0.01f;

                red.GetComponent<Image>().color = color;
            }
        }
	}

    private void DecreaseHealth()
    {
        if (healthCount <= 0f)
        {
            egPauseManager.instance.PauseGame();
        }
        else if (Player.instance.scoremultiplier <= 0f)
        {
            Player.instance.scoremultiplier = 0f;
        }
        else
        {
            Player.instance.scoremultiplier -= 1.0f;
            AudioManager.instance.SFX[1].Play();
            healthCount -= 1f;
        }
    }

    public float GetHealth()
    {
        return healthCount;
    }
    private void Awake()
    {
        instance = this;
    }
}