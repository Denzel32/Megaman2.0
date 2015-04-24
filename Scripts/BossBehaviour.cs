using UnityEngine;
using System.Collections;

public enum EnemyState
{
    Idle,
    Attack
}

public class BossBehaviour : MonoBehaviour 
{
    private EnemyState myState;
    private Vector2 startpos;
    public float moveSpeed;
    private int direction = 1;
    public int maxOffset = 3;
    private bool facingRight;
    public int health;
    public int collisionDmg = 20;
    public bool isDeath;
    public Animator anim;
    public float timer;
    private bool canAttack;
    public GameObject bullet;
    public Transform bulletSpawn;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        startpos = transform.position;
        canAttack = false;
        myState = EnemyState.Idle;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(500,10 , 100, 100), "bossHealth: " + health);
    }
	
	// Update is called once per frame
	void Update () 
    {
        Movement();
        ChangeDir();
	}

    void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            print("I am dead now");
            isDeath = true;
            Destroy(this.gameObject);
            Application.LoadLevel("GameEnd");
        }
    }

    void Movement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right *- moveSpeed * direction;
    }

    void ChangeDir()
    {
        if (transform.position.x > startpos.x + maxOffset)
        {
            direction = 1;
            //print(direction);
            if (facingRight)
            {
                Flip();
            }
        }
        else if (transform.position.x < startpos.x - maxOffset)
        {
            direction = -1;
            //print(direction);
            if (!facingRight)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SendMessage("TakeDamageOnCollision", collisionDmg);
        }
    }
}
