using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasonChange : MonoBehaviour {

    private Animation anim;
    public static string season;
    private float time = 20;
    private GameObject[] menus;
    private Animation anim1;
    private string manNumber;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animation>();
        season = "spring";//spring;summer;fall;winter
        InvokeRepeating("changeSeason", time, time);
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void changeSeason()
    {
        if (season.Equals("spring"))
        {
            season = "summer";
            anim.Play("SpringToSummer");
        }
        else if (season.Equals("summer"))
        {
            season = "fall";
            anim.Play("SummerToFall");
        }
        else if (season.Equals("fall"))
        {
            season = "winter";
            anim.Play("FallToWinter");
        }
        else if (season.Equals("winter"))
        {
            season = "spring";
            anim.Play("WinterToSpring");
        }

        menus = GameObject.FindGameObjectsWithTag("menu");
        foreach (GameObject menu in menus)
        {
            if (menu.activeSelf)
            {
                anim1 = menu.transform.parent.GetComponent<Animation>();
                manNumber = menu.transform.parent.tag;
                if (manNumber.Equals("man1"))
                {
                    anim1["man1"].wrapMode = WrapMode.Loop;
                    anim1.PlayQueued("man1");
                }
                else if (manNumber.Equals("man2"))
                {
                    anim1["man2"].wrapMode = WrapMode.Loop;
                    anim1.PlayQueued("man2");
                }
                else if (manNumber.Equals("man3"))
                {
                    anim1["man3"].wrapMode = WrapMode.Loop;
                    anim1.PlayQueued("man3");
                }
                else if (manNumber.Equals("man4"))
                {
                    anim1["man4"].wrapMode = WrapMode.Loop;
                    anim1.PlayQueued("man4");
                }
                else if (manNumber.Equals("man5"))
                {
                    anim1["man5"].wrapMode = WrapMode.Loop;
                    anim1.PlayQueued("man5");
                }
                menu.transform.parent.gameObject.GetComponent<move>().isMove = true;
                menu.transform.parent.GetComponent<press>().isPress = false;
                menu.SetActive(false);
            }
        }

    }

}
