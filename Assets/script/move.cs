using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private float x;
    private float y;
    private float minusX;
    private float minusY;
    private bool upRight;

    // Use this for initialization
    void Start () {
        x = Random.Range(0.2f, 0.4f);
        y = Random.Range(0.05f, 0.2f);
        //Debug.Log(x);
        //Debug.Log(y);
        minusX = Random.value;
        minusY = Random.value;
        upRight = false;
        if (minusX < 0.5f)
        {
            //Debug.Log("a");
            x = -x;
            upRight = true;
        }
        if (minusY < 0.5f)
        {
            //Debug.Log("b");
            y = -y;
        }
        if (!upRight)
        {
            GetComponent<Animation>().PlayQueued("leftFlip");
            //Debug.Log("aa");
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.position += new Vector3(x, y, 0);
        if (transform.position.x > 215.84 || transform.position.x < -215.84)
        {
            //Debug.Log("c");
            x = -x;
            if(upRight)
                GetComponent<Animation>().PlayQueued("leftFlip");
            else
                GetComponent<Animation>().PlayQueued("rightFlip");
            upRight = !upRight;
        }
        if (transform.position.y > 43.64 || transform.position.y < -43.64)
        {
            //Debug.Log("d");
            y = -y;
        }

        //Debug.Log(x);
        //Debug.Log(y);    
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        
        x = -x;
        y = -y;
        if (upRight)
        {
            GetComponent<Animation>().PlayQueued("sayHiRight");
            GetComponent<Animation>().PlayQueued("leftFlip");
        }
        else
        {
            GetComponent<Animation>().PlayQueued("sayHiLeft");
            GetComponent<Animation>().PlayQueued("rightFlip");
        }
            
        upRight = !upRight;
    }
}
