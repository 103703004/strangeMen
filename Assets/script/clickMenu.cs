using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickMenu : MonoBehaviour {

    private Animation anim;
    private string manNumber;

	// Use this for initialization
	void Start () {
        anim = transform.parent.transform.parent.GetComponent<Animation>();
        manNumber = transform.parent.transform.parent.tag;
        Debug.Log(manNumber);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void menu1()
    {

        if (manNumber.Equals("man1"))
            anim.Stop("man1");
        else if (manNumber.Equals("man2"))
            anim.Stop("man2");
        else if(manNumber.Equals("man3"))
            anim.Stop("man3");
        else if (manNumber.Equals("man4"))
            anim.Stop("man4");
        else if (manNumber.Equals("man5"))
            anim.Stop("man5");

        anim.PlayQueued("dropWreath");

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

        transform.parent.gameObject.SetActive(false);
    }

    public void menu2()
    {
        //transform.parent.transform.parent.GetComponent<Animation>().PlayQueued("");
        transform.parent.gameObject.SetActive(false);
    }

    public void menu3()
    {
        //transform.parent.transform.parent.GetComponent<Animation>().PlayQueued("");
        transform.parent.gameObject.SetActive(false);
    }
}
