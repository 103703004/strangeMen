using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasonChange : MonoBehaviour {

    public static string season;
    private float time = 10;

	// Use this for initialization
	void Start () {
        season = "spring";//spring;summer;fall;winter
        InvokeRepeating("changeSeason", time, time);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void changeSeason()
    {
        if (season.Equals("spring"))
            season = "summer";
        else if (season.Equals("summer"))
            season = "fall";
        else if (season.Equals("fall"))
            season = "winter";
        else if (season.Equals("winter"))
            season = "spring";
    }
}
