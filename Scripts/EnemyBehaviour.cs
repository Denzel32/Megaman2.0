using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour 
{
    private Vector2 startpos;
    public float moveSpeed;
    private int direction = 1;
    public int maxOffset = 3;
    private bool facingRight;
    private int health = 20;
    public int collisionDmg = 20;
    public bool isDeath;
    public Animator anim;
    public GameObject enemyBullet;
    public Transform enemyBulletSpawn;

    public Transform startSight;
    public Transform endSight;
    //public EnemyFire fire; //reference to the enemyfire script

    public bool spotted = false;

   

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        RayCasting();
        Behaviours();
	}

    void TakeDamage(int damage)
    {
        health = health - damage;

        if(health < 0)
        {
            print("I am dead now");
            isDeath = true;
            Destroy(this.gameObject);
            
        }
    }

    void RayCasting()
    {
        //Drawing a line from the startsight to endsight. Only allowing it to see the object that has the player layer tag.
        Debug.DrawLine(startSight.position, endSight.position, Color.green);
        spotted = Physics2D.Linecast(startSight.position, endSight.position, 1 << LayerMask.NameToLayer("Player"));

    }

    void Behaviours()
    {
        if (spotted == true)
        {
            Instantiate(enemyBullet, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
        }
    }

   void OnCollisionEnter2D(Collision2D collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            collide.transform.SendMessage("TakeDamageOnCollision", collisionDmg);
        }
    }
}
