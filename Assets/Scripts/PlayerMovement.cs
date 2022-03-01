﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpforce = 400f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool nomorejumo;

    [SerializeField] Transform groundCheck;
    [SerializeField] float grounddistance = 0.2f;
    private void FixedUpdate ()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        nomorejumo = Physics.CheckSphere(groundCheck.position, grounddistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && nomorejumo)
        {
            rb.AddForce(Vector3.up * jumpforce);
        }

        else
        {
            nomorejumo = false;
        }
        if (transform.position.y < -5) {
            Die();
        }
	}

    public void Die ()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}