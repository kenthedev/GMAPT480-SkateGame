using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {
    

    PlayerMovement playerMovement;
    public float healthCount = 3f;
    public static Obstacle instance;

    private void Start () {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
	}

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "spike") {
            // Kill the player
            Debug.Log("Player hit!");
            Destroy(collision.gameObject);
            DecreaseHealth();
        }
    }

    private void Update () {
	
	}

    private void DecreaseHealth()
    {
        if (healthCount <= 0f)
        {
            egPauseManager.instance.PauseGame();
        }
        else
        {
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