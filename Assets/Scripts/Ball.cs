using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRB;
    [SerializeField] private float jumpForce = 6;
    public AudioSource bounce, levelPassed, gameOver;
    public GameObject goPanel, lpPanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Unsafe")
        {
            CanvasManager.gameOver = true;
            goPanel.SetActive(true);
            Time.timeScale = 0;
            gameOver.Play();
        }
        else if (collision.gameObject.tag == "Finish" && !CanvasManager.levelPassed)
        {
            CanvasManager.levelPassed = true;
            lpPanel.SetActive(true);
            levelPassed.Play();
            bounce.Play();
            ballRB.velocity = new Vector3(ballRB.velocity.x, jumpForce, ballRB.velocity.z);
        }
        else
        {
            bounce.Play();
            ballRB.velocity = new Vector3(ballRB.velocity.x, jumpForce, ballRB.velocity.z);
        }
    }
}
