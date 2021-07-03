using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
     bool shooting;

    void Start()
    {
        PoolManager.instance.CreatePool(shot, 100);
        
    }

    void Update()
    {
        if (gameObject.activeSelf == true && shooting == false)
        {
            InvokeRepeating("Fire", delay, fireRate);
            shooting = true;
        }

        if (Camera.main.transform.position.y - gameObject.transform.position.y >= 4.32f)
        {
            CancelInvoke();
            shooting = false;
        }
           
    }
    void Fire()
    {
        PoolManager.instance.ReuseObject(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
