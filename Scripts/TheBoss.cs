using UnityEngine;
using System.Collections;

public class TheBoss : MonoBehaviour {
    public float moveSpeed;
    private Vector2 startpos;
    private int direction = 1;
    public int maxOffset = 3;
    private bool facingRight;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Movement();
        ChangeDir();
	}

    void Attack()
    {

    }

    void Movement()
    {
        GetComponent <Rigidbody2D>().velocity = Vector2.right *- moveSpeed;
    }

    void ChangeDir()
    {
        if (transform.position.x > startpos.x + maxOffset)
        {
            direction = -1;
            //print(direction);
            if (!facingRight)
            {
                Flip();
            }
        }
        else if (transform.position.x < startpos.x - maxOffset)
        {
            direction = 1;
            //print(direction);
            if (facingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision collide)
    {
        if(collide.gameObject.tag == "Wall")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
