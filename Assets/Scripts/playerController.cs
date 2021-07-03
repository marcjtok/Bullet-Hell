using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Done_Boundary
{
    public float xMin, xMax;
}

public class playerController : MonoBehaviour {

    public float speed;
    public Done_Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public Sprite Purple;
    public Sprite Green;
    public float delay;

    private Animator animator;
    public RuntimeAnimatorController greenAnim;
    public RuntimeAnimatorController purpleAnim;

    bool checkBounce;

    void Fire()
    {
        PoolManager.instance.ReuseObject(shot, shotSpawn.position, shotSpawn.rotation);
        //shot.transform.parent = Camera.main.transform;
    }

    // Use this for initialization
    void Start ()
    {
        PoolManager.instance.CreatePool(shot, 50);
        InvokeRepeating("Fire", delay, fireRate);
        animator = gameObject.GetComponent<Animator>();
        checkBounce = false;
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (checkBounce == true)
        {
            if (gameObject.transform.position.x <= 0.0f)
                shotSpawn.rotation = Quaternion.Euler(new Vector3(0, 0, -25f));
            else if (gameObject.transform.position.x > 0.0f)
                shotSpawn.rotation = Quaternion.Euler(new Vector3(0, 0, 25f));
        }

        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        transform.Translate(touchDeltaPosition.x * 0.33f * Time.deltaTime, touchDeltaPosition.y * 0.28f * Time.deltaTime, 0);
        transform.position = new Vector2
        (
            Mathf.Clamp(transform.position.x, Camera.main.transform.position.x - 2.6f, Camera.main.transform.position.x + 2.6f),
            Mathf.Clamp(transform.position.y, Camera.main.transform.position.y - 4.8f, Camera.main.transform.position.y + 4.5f)
        );

        if (Input.GetTouch(1).phase == TouchPhase.Began)
        {
            if (gameObject.tag == "Green")
            {
                gameObject.tag = "Purple";
                this.GetComponent<SpriteRenderer>().sprite = Purple;
                animator.runtimeAnimatorController = purpleAnim;
                checkBounce = false;
                shotSpawn.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            }
            else
            {
                gameObject.tag = "Green";
                this.GetComponent<SpriteRenderer>().sprite = Green;
                animator.runtimeAnimatorController = greenAnim;
                checkBounce = true;
                
            }
        }



        /*
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody2D>().velocity = movement * speed * Time.deltaTime;
        
        
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Green")
            {
                gameObject.tag = "Purple";
                this.GetComponent<SpriteRenderer>().sprite = Purple;
                animator.runtimeAnimatorController = purpleAnim;

            }
            else
            {
                gameObject.tag = "Green";
                this.GetComponent<SpriteRenderer>().sprite = Green;
                animator.runtimeAnimatorController = greenAnim;
            }

        }*/
    }
}
