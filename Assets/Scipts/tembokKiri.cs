using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembokKiri : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is the ball
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the position of the ball
            collision.gameObject.GetComponent<BallController>().ResetBall();
        }
    }
}
