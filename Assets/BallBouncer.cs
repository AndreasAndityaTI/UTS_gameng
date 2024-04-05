using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Public variables
    public int force;
    public float speed = 5f;

    // Private variables
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component
        rigid = GetComponent<Rigidbody2D>();

        // Launch the ball
        Vector2 arah = new Vector2(0, 2).normalized;
        rigid.AddForce(arah * force);
    }

    // Update is called once per frame
    void Update()
    {
        // Unused code
    }

    // OnCollisionEnter2D is called when the ball collides with something
    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Check if the ball collides with a player
        if (coll.gameObject.CompareTag("playerMerah") || coll.gameObject.CompareTag("playerBiru"))
        {
            // Calculate the direction of the bounce based on the collision normal
            Vector2 bounceDirection = Vector2.Reflect(rigid.velocity.normalized, coll.contacts[0].normal).normalized;

            // Reset the ball's velocity and add force to simulate a bounce
            rigid.velocity = Vector2.zero;
            rigid.AddForce(bounceDirection * force, ForceMode2D.Impulse);
        }
            Debug.Log("Collision detected with: " + coll.gameObject.name);

    }
}
