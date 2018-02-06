using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class press : MonoBehaviour {

    private Animation anim;
    private string manNumber;
    public bool isPress;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        manNumber = tag;
        isPress = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        GameObject menu = gameObject.transform.Find("menu").gameObject;
        menu.SetActive(!menu.activeInHierarchy);
        if (!menu.activeSelf)
        {
            isPress = false;
            gameObject.GetComponent<move>().isMove = true;
            StartAnimMain();
        }
        else
        {
            isPress = true;
            gameObject.GetComponent<move>().isMove = false;
            StopAnimMain();
        }

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

}
