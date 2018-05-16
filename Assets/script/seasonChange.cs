using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasonChange : MonoBehaviour {

    private Animation anim;
    public static string season;
    private float time = 30;

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
    }
}
