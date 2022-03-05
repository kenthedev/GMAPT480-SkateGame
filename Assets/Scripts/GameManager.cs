using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Obstacle obstacle;

    public void IncrementScore ()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public void DecreaseHealth()
    {
        float health = obstacle.GetHealth();
        healthText.text = "HEALTH: " + health.ToString();
    }

    private void Awake ()
    {
        inst = this;
    }

    private void Start () {

	}

	private void Update () {
	
	}
}