using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public int health;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Sphere Barrier_0") != null && GameObject.Find("Player") != null)
        {
           transform.position = player.transform.position;
           gameObject.tag = GameObject.Find("Player").tag;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            health = 3;
        }
        if(player.tag =="Green")
        {
            gameObject.tag = "Green";
        }
        if(player.tag =="Purple")
        {
            gameObject.tag = "Purple";
        }

        gameObject.transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GreenBul" && gameObject.tag == "Purple")
        {
            collision.gameObject.SetActive(false);
            --health;
        }
        else if (collision.gameObject.tag == "PurpleBul" && gameObject.tag == "Green")
        {
            collision.gameObject.SetActive(false);
            --health;
        }
        else if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Purple")
        {
            collision.gameObject.SetActive(false);
            --health;
        }
        else if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Green")
        {
            collision.gameObject.SetActive(false);
            --health;
        }

       
        else
        {
            return;
        }
       
    }

}
