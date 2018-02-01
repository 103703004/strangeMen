using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private float x;
    private float y;
    private float minusX;
    private float minusY;
    private bool upRight;
    private Animation anim;
    private string manNumber;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        manNumber = tag;
        Debug.Log(manNumber);
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
            StopAnimMain();

            anim.PlayQueued("leftFlip");

            StartAnimMain();
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(x, y, 0);
        if (transform.position.x > 215.84 || transform.position.x < -215.84)
        {
            //Debug.Log("c");
            x = -x;

            StopAnimMain();

            if (upRight)
                anim.PlayQueued("leftFlip");
            else
                anim.PlayQueued("rightFlip");

            upRight = !upRight;

            StartAnimMain();
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

        StopAnimMain();

        if (upRight)
        {
            anim.PlayQueued("sayHiRight");
            anim.PlayQueued("leftFlip");
        }
        else
        {
            anim.PlayQueued("sayHiLeft");
            anim.PlayQueued("rightFlip");
        }
            
        upRight = !upRight;

        StartAnimMain();
    }

    private void StopAnimMain()
    {
        if (manNumber.Equals("man1"))
            anim.Stop("man1");
        else if (manNumber.Equals("man2"))
            anim.Stop("man2");
        else if (manNumber.Equals("man3"))
            anim.Stop("man3");
        else if (manNumber.Equals("man4"))
            anim.Stop("man4");
        else if (manNumber.Equals("man5"))
            anim.Stop("man5");
    }

    private void StartAnimMain()
    {
        if (manNumber.Equals("man1"))
        {
            anim["man1"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man1");
        }
        else if (manNumber.Equals("man2"))
        {
            anim["man2"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man2");
        }
        else if (manNumber.Equals("man3"))
        {
            anim["man3"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man3");
        }
        else if (manNumber.Equals("man4"))
        {
            anim["man4"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man4");
        }
        else if (manNumber.Equals("man5"))
        {
            anim["man5"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man5");
        }
    }
}
