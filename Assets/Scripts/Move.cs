using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Move : MonoBehaviour
{
	public float speed;

	void Update ()
	{
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;

        if (!GetComponent<Renderer>().isVisible)
            gameObject.SetActive(false);
	}
}
