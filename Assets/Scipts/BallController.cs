using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized;
        rigid.AddForce(arah * force);
    }

    void Update()
    {
        
    }
    

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "TepiKanan")
        {
            ResetBall();
            Vector2 arah = new Vector2(0, 2).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "TepiKiri")
        {
            ResetBall();
            Vector2 arah = new Vector2(0, -2).normalized;
            rigid.AddForce(arah * force);
        }
if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
{
float sudut = (transform.position.y - coll.transform.position.y) * 5f;
Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
rigid.velocity = new Vector2(0, 0);
rigid.AddForce(arah * force * 2);
}
    }

    public void ResetBall() 
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0f;
    }
}
