using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMovement : MonoBehaviour {

    public float camMoveSpeed;
    public GameObject[] Backgrounds;
    int prevIndex;
    int currIndex;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < Backgrounds.Length; ++i)
        {
            PoolManager.instance.CreatePool(Backgrounds[i], 2);
        }

        prevIndex = Random.Range(0, 3);
        PoolManager.instance.ReuseObject(Backgrounds[prevIndex], new Vector3(0,-1.85f,0), Quaternion.identity);
        do
        {
            currIndex = Random.Range(0, 3);
        } while (currIndex == prevIndex);

        PoolManager.instance.ReuseObject(Backgrounds[currIndex], new Vector3(0, 4.423f, 0), Quaternion.identity);
        prevIndex = currIndex;
        
    }

    float addBg = 2.5f;
    float yPosToAddBG = 10.696f;

	// Update is called once per frame
	void Update () 
    {
        transform.position += new Vector3(0, camMoveSpeed * Time.deltaTime, 0);

		if (transform.position.y >= addBg)
        {
            do
            {
                currIndex = Random.Range(0, 3);
            } while (currIndex == prevIndex);

            PoolManager.instance.ReuseObject(Backgrounds[currIndex], new Vector3(0, yPosToAddBG, 0), Quaternion.identity);
            prevIndex = currIndex;


            //random.range for int is not maximally inclusive.
            //Instantiate(Backgrounds[Random.Range(0, 4)], new Vector3(0, yPosToAddBG, 0), Quaternion.identity);
            addBg += 6.273f;
            yPosToAddBG += 6.273f;
        }
	}
}
