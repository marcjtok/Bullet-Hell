using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColor : MonoBehaviour {

    public Sprite greenUI;
    public Sprite purpleUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Player").tag == "Green")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = greenUI;
        }

        if (GameObject.Find("Player").tag == "Purple")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = purpleUI;
        }
    }
}
