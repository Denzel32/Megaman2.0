using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
    public float health;
    public float maxHealth;

	// Use this for initialization
	void Start () 
    {
        health = maxHealth;
        
	}
    
    void OnGUI()
    {
        GUI.Label(new Rect(10,10, 100,100), "Your Health: " + health);
    }

    void TakeDamageOnCollision(int collisionDmg)
    {
        health = health - collisionDmg;
        if(health <= 0)
        {
            print("megaman is mega dead");
            Application.LoadLevel("GameOver");
        }
        
    }
}
