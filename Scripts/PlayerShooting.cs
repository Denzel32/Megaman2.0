using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour 
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed;
    private Animator anim;
    public float shootTimer;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Timer();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(shootTimer >= 0.5)
            {
                 GameObject b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject; 
                 b.transform.localScale = transform.localScale;
                 shootTimer = 0;
            }
        }
    }

    void Timer()
    {
        shootTimer += Time.deltaTime;
    }
}
