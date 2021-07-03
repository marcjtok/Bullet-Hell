using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderCheck : MonoBehaviour
{

    private float seqTimer;
    public GameObject player;
    public GameObject Barrier;
    private bool one;
    private bool two;
    private bool three;
    public bool isDead;
    public int scoreValue = 10;
    public Animator animator;
    public int health;

    bool barrierCheck = true;

    bool purpleCheck;
    bool greenCheck;

    public GameObject purpDiamond;
    public GameObject greenDiamond;

    public GameObject combo1;
    public GameObject combo2;
    public GameObject combo3;

    GameObject p;
    GameObject g;

    public GameObject playerShots;
    // Use this for initialization
    void Start()
    {
        one = false;
        two = false;
        three = false;

        purpleCheck = false;
        greenCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Sphere Barrier_0") != null)
            barrierCheck = false;
        if (GameObject.Find("Sphere Barrier_0") == null)
            barrierCheck = true;

        //PoolManager.instance.CreatePool(playerShots, 50);
    }

    void destroyCombo()
    {
        GameObject[] comboDiamonds = GameObject.FindGameObjectsWithTag("Combo");

        for (int i = 0; i < comboDiamonds.Length; ++i)
            Destroy(comboDiamonds[i]);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "PlayerBul")
        {
            health--;
            Game_Manager.score += scoreValue;
            takeDamage();
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            return;
        }

        if (other.gameObject.tag == "Enemy" && gameObject.name == "Player")
        {
            Destroy(gameObject);

            purpleCheck = false;
            greenCheck = false;

            barrierCheck = true;
            return;

            destroyCombo();
        }
    
        if (other.gameObject.tag == "PurpleBul" && gameObject.name == "Player")
        {

            if (gameObject.tag != "Purple")
            {
                health--;
                takeDamage();
                Destroy(gameObject);
                    other.gameObject.SetActive(false);
                    one = false;
                    two = false;
                    three = false;
                    barrierCheck = true;

                purpleCheck = false;
                greenCheck = false;
                destroyCombo();
                return;
            }

            if (purpleCheck == true)
                return;
            else if (purpleCheck == false)
            {
                if ((gameObject.tag == "Purple") && (barrierCheck == true) && (one == true) && (two == true))
                {
                    three = true;

                    p = Instantiate(purpDiamond, combo3.transform.position, Quaternion.identity);
                    p.transform.parent = Camera.main.transform;
                    Invoke("destroyCombo", 2.0f);

                    if (one == true && two == true && three == true)
                    {
                        Instantiate(Barrier, gameObject.transform.position, gameObject.transform.rotation);
                        one = false;
                        two = false;
                        three = false;
                        barrierCheck = false;
                    }
                    purpleCheck = true;
                    return;
                }

                if ((gameObject.tag == "Purple") && (barrierCheck == true) && (one == true))
                {
                    one = false;
                    purpleCheck = true;
                    destroyCombo();
                    return;
                }

                if ((gameObject.tag == "Purple") && (barrierCheck == true))
                {
                    one = true;
                    purpleCheck = true;
                    p = Instantiate(purpDiamond, combo1.transform.position, Quaternion.identity);
                    p.transform.parent = Camera.main.transform;
                    return;
                }


                return;
            }
           
        }
     
        if (other.gameObject.tag == "GreenBul" && gameObject.name == "Player")
        {
            if (gameObject.tag != "Green")
            {
                health--;
                takeDamage();
                Destroy(gameObject);
                one = false;
                two = false;
                three = false;
                barrierCheck = true;

                purpleCheck = false;
                greenCheck = false;
                destroyCombo();
            }

            if (greenCheck == true)
                return;
            else if (greenCheck == false)
            {
                if ((gameObject.tag == "Green") && (barrierCheck == true) && (one == true) && (two == true))
            {
                    one = false;
                    two = false;
                    destroyCombo();
                }

                if ((gameObject.tag == "Green") && (barrierCheck == true) && (one == true))
                {
                    two = true;
                   
                    g = Instantiate(greenDiamond, combo2.transform.position, Quaternion.identity);
                    g.transform.parent = Camera.main.transform;
                }
                greenCheck = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "GreenBul" && gameObject.name == "Player")
        {
            greenCheck = false;
        }

        if (other.gameObject.tag == "PurpleBul" && gameObject.name == "Player")
        {
            
            purpleCheck = false;
        }
    }

    void takeDamage()
    {

        wait();
        
    }
    
    IEnumerator wait()
    {
        animator.SetBool("takeDamage", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("takeDamage", false);

    }

    /*
            if (other.gameObject.tag == "PurpleBul" && gameObject.name == "Player")
            {
                if (player.tag != "Purple")
                    Destroy(gameObject);
            }
            if (other.gameObject.tag == "GreenBul" && gameObject.name == "Player")
            {
                if (player.tag != "Green")
                    Destroy(gameObject);
            }

            if (other.gameObject.tag == "PurpleBul" && gameObject.name == "Player")
            {
                if (player.tag == "Purple")
                    one = true;
            }
            if (other.gameObject.tag == "GreenBul" && gameObject.name == "Player" && one == true)
            {
                if (player.tag == "Green")
                    two = true;
            }
            if (other.gameObject.tag == "PurpleBul" && gameObject.name == "Player" && one == true && two == true)
            {
                if (player.tag == "Purple")
                    three = true;
            }
            if (one == true && two == true && three == true)
            {
                GameObject barrier1 = Instantiate(Barrier, player.transform.position, player.transform.rotation);
                one = false;
                two = false;
                three = false;

            }*/
}


