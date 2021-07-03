using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCounter : MonoBehaviour {
    public int health;

    public GameObject health1, health2, health3;
    
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        health = GameObject.Find("Player").GetComponent<colliderCheck>().health;

        if (health ==3)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(true);
        }
        else if (health == 2)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(false);
        }
        else if (health == 1)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
        }
        else
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
        }
    }
}
