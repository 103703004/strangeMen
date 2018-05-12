using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

    public AudioClip tree;
    public AudioClip moonFest;
    public AudioClip maple;
    public AudioClip crab;
    private AudioSource audioS;

	// Use this for initialization
	void Start () {
        audioS = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void playMaple()
    {
        audioS.PlayOneShot(maple);
    }

    void playCrab()
    {
        audioS.PlayOneShot(crab);
    }

    void playMoonFest()
    {
        audioS.PlayOneShot(moonFest);
    }

    void playTree()
    {
        audioS.PlayOneShot(tree);
    }
}
