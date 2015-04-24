using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public Animator anim;
    private bool facingRight;
    public float jumpSpeed;
    private bool jump = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D Collide)
    {
        Debug.Log("hitting ground");
        Debug.Log(jump);
        if(Collide.gameObject.tag == "Platform")
        {
            jump = true;
        }
        else
        {
            anim.SetBool("Jumping", true);
        }

        if(Collide.gameObject.tag == "EndStage")
        {
            Application.LoadLevel("bossfight");
        }
    }
    void Movement()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (facingRight)
            {
                Flip();
            }
            anim.SetFloat("Speed", 1);

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * -speed * Time.deltaTime);
            anim.SetFloat("Speed", 1);

            if (!facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Jumping", true);
            if (jump == true)
            {

                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
                jump = false;
            }

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Jumping", false);
        }
    }
}

