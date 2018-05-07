using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

    public AudioClip tree;
    public AudioSource audioS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void playTree()
    {
        audioS.PlayOneShot(tree);
    }
}
