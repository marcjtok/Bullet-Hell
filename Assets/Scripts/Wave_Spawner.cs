using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Spawner : MonoBehaviour
{
    public GameObject[] enemy;                // The enemy prefab to be spawned.`
    private float spawnTime = 1.5f;            // How long between each spawn.
    public GameObject spawnPoint;

    float spawnIncreaseTimer = 2f;
    float timeElapsed = 0f;

    bool spawnKamikaze = true;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.

        for (int i = 0; i < enemy.Length;++i)
        {
            PoolManager.instance.CreatePool(enemy[i], 100);
        }
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void FixedUpdate()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        timeElapsed += Time.deltaTime;
        {
            if (timeElapsed >= spawnIncreaseTimer)
            {
                spawnTime /= 1.1f;
                if (spawnTime <= 0.6F)
                {
                    spawnTime = 0.6F;
                }
                timeElapsed = 0f;
                IncreaseSpawn();
            }
        }


        if (GameObject.Find("Player") == null)
            spawnTime = 0.1f;
    }

    void IncreaseSpawn()
    {
        CancelInvoke();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        int enemyIndex;
        // Find a random index between zero and one less than the number of spawn points.
        if (spawnKamikaze == true)
            enemyIndex = Random.Range(0, enemy.Length);
        else
            enemyIndex = Random.Range(1, enemy.Length);

        if (enemyIndex != 0)
        {
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            PoolManager.instance.ReuseObject(enemy[enemyIndex], new Vector3(Random.Range(-2.35f, 2.352f), spawnPoint.transform.position.y, 0.0f), Quaternion.Euler(0, 0, 180));
            /*GameObject teki = Instantiate(enemy[enemyIndex], new Vector3(Random.Range(-2.35f, 2.352f), spawnPoint.transform.position.y, 0.0f), Quaternion.Euler(0, 0, 180));
            teki.transform.parent = Camera.main.transform;*/
            //instantiate subject to change
        }
        else if (enemyIndex == 0 && spawnKamikaze == true)
        {
            float xPos = Random.Range(-2.35f, 2.352f); 
            StartCoroutine( spawnInARow(xPos,enemyIndex, 3) );
        }

        
    }

    IEnumerator spawnInARow(float xPos, int enemyIndex, int counter)
    {
        while (counter > 0)
        {
            spawnKamikaze = false;
            yield return new WaitForSeconds(0.5f);
            PoolManager.instance.ReuseObject(enemy[enemyIndex], new Vector3(xPos, spawnPoint.transform.position.y, 0.0f), Quaternion.Euler(0, 0, 180));
            /*
            GameObject teki1 = Instantiate(enemy[enemyIndex], new Vector3(xPos, spawnPoint.transform.position.y, 0.0f), Quaternion.Euler(0, 0, 180));
            teki1.transform.parent = Camera.main.transform;*/
            --counter;
        }
        if (counter == 0)
        {
            spawnKamikaze = true;
        }
    }
}