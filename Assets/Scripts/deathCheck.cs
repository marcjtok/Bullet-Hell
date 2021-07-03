using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathCheck : MonoBehaviour {

    public bool isDead;
    // Use this for initialization
    void Start()
    {
        isDead = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            isDead = true;
        }
        if (isDead == true)
        {
            Invoke("Reload", 2);
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
