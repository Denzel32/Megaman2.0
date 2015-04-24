using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
    public float speed;
    public float destructionTime;
    public int damage = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(speed * transform.localScale.x * Time.deltaTime, 0, 0);
        DestroyAfterTime();
	}

    void DestroyAfterTime()
    {
        Destroy(this.gameObject, 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            print("I just hit the enemy");
            other.transform.SendMessage("TakeDamage", damage);
            Destroy(this.gameObject);
        }
    }
}
