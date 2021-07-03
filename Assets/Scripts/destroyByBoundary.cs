using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByBoundary : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "PlayerBul" || other.gameObject.tag == "GreenBul"
            || other.gameObject.tag == "PurpleBul" ||other.gameObject.tag == "Enemy"  )
            other.gameObject.SetActive(false);
        
    }
}
