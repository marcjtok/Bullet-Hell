using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgDelete : MonoBehaviour {

    Camera camera;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if( (!GetComponent<Renderer>().isVisible) && ( (camera.transform.position.y - transform.position.y) >= 8.123f) )
        {
            gameObject.SetActive(false);
        }
	}
}
