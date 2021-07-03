using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour {

    public float speed;
    public float delay;
    private float timer;
    public GameObject prefab;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        PoolManager.instance.CreatePool(prefab, 100);
    }

    int count = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay && count < 2)
        {
            StartCoroutine("wait");
            timer = 0;
        }

        if (((Camera.main.transform.position.y - transform.position.y) >= 5.2f) ||  transform.position.x >= 2.97f || transform.position.x <= -2.97f)
            gameObject.SetActive(false);
    }
    IEnumerator wait()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 8; ++i)
        {
            PoolManager.instance.ReuseObject(prefab, transform.position, Quaternion.Euler(0,0,i * 45));
        }

        gameObject.SetActive(false);
        
        //Destroy(gameObject);
        /*
        Rigidbody2D clone;
        clone = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone.GetComponent<ExplodingBullet>().enabled = false;
        clone.velocity = transform.TransformDirection(Vector2.down * speed);
        clone.tag = "PurpleBul";

        Rigidbody2D clone1;
        clone1 = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone1.GetComponent<ExplodingBullet>().enabled = false;
        clone1.GetComponent<CircleCollider2D>().enabled = true;
        clone1.velocity = transform.TransformDirection(Vector2.right * speed);
        clone1.tag = "PurpleBul";

        Rigidbody2D clone2;
        clone2 = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone2.GetComponent<ExplodingBullet>().enabled = false;
        clone2.GetComponent<CircleCollider2D>().enabled = true;
        clone2.velocity = transform.TransformDirection(Vector2.left * speed);
        clone2.tag = "PurpleBul";

        /*Rigidbody2D clone3;
        clone3 = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone3.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone3.GetComponent<ExplodingBullet>().enabled = false;
        clone3.GetComponent<CircleCollider2D>().enabled = true;
        clone3.velocity = transform.TransformDirection(Vector2.up * speed);
        clone3.tag = "PurpleBul";

        Rigidbody2D clone4;
        clone4 = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone4.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone4.GetComponent<ExplodingBullet>().enabled = false;
        clone4.GetComponent<CircleCollider2D>().enabled = true;
        clone4.velocity = transform.TransformDirection(Vector2.down * speed + Vector2.left * speed);
        clone4.tag = "PurpleBul";

        Rigidbody2D clone5;
        clone5 = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone5.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone5.GetComponent<ExplodingBullet>().enabled = false;
        clone5.GetComponent<CircleCollider2D>().enabled = true;
        clone5.velocity = transform.TransformDirection(Vector2.down * speed + Vector2.right * speed);
        clone5.tag = "PurpleBul";

        Rigidbody2D clone6;
        clone6 = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone6.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone6.GetComponent<ExplodingBullet>().enabled = false;
        clone6.GetComponent<CircleCollider2D>().enabled = true;
        clone6.velocity = transform.TransformDirection(Vector2.up * speed + Vector2.left * speed);
        clone6.tag = "PurpleBul";

        Rigidbody2D clone7;
        clone7 = Instantiate(prefab, transform.position, transform.rotation) as Rigidbody2D;
        clone7.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        clone7.GetComponent<ExplodingBullet>().enabled = false;
        clone7.GetComponent<CircleCollider2D>().enabled = true;
        clone7.velocity = transform.TransformDirection(Vector2.up * speed + Vector2.right * speed);
        clone7.tag = "PurpleBul";

        Destroy(gameObject);*/
    }
}
