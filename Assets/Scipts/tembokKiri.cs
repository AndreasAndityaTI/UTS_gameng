using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembokKiri : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Reset the position of the ball
            collision.gameObject.GetComponent<BallController>().ResetBall();
        }
    }
}
