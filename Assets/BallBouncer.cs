using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    // Speed of the ball
    public float speed = 5f;

    // Start position of the ball
    private Vector3 startPosition;

    // Direction of the ball
    private Vector3 direction = Vector3.right;

    // Distance the ball should travel before bouncing back
    public float distance = 5f;

    // Rigidbody component of the ball

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the ball
        //startPosition = transform.position;

        // Get the Rigidbody component
        //rb = GetComponent<Rigidbody>();
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized;
        rigid.AddForce(arah * force);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ball in the specified direction
       // rigid.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    // OnCollisionEnter is called when the ball collides with something
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Basic Racket (4)" || coll.gameObject.name == "Basic Racket (5)")
        {
            float sudut = (transform.position.x - coll.transform.position.x) * 5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 4);
        } // Reverse the direction of the ball
    }
}
