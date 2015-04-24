using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour 
{
    public GameObject enemy;
    public Transform[] enemySpawnPoints;
    public int count;
    public float startWait;
    public float waveWait;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Spawn());
	}

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startWait);
        while(count > 0)
        {
            count--;
            Instantiate(enemy, enemySpawnPoints[(Random.Range(0, enemySpawnPoints.Length))].position, Quaternion.identity);
        }
        yield return new WaitForSeconds(waveWait);
        if(count == 0)
        {
            count = 5;
        }
    }
}
