using UnityEngine;

public class playerMerah : MonoBehaviour
{
    // Speed of the movement
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input (left and right arrow keys)
        float moveHorizontal = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveHorizontal = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            moveHorizontal = 1f;

        // Calculate the movement direction
        Vector3 movement = Vector3.right * moveHorizontal;

        // Move the object based on the input and speed
        transform.Translate(movement * speed * Time.deltaTime);
    }

    // Called when colliding with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Get the Rigidbody component of the ball
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Calculate the direction of the bounce
            Vector3 bounceDirection = (collision.contacts[0].point - transform.position).normalized;

            // Apply force to the ball to simulate a bounce
            ballRigidbody.AddForce(bounceDirection * speed, ForceMode.Impulse);
        }
    }
}