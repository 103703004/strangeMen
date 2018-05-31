using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

    public AudioClip tree;
    public AudioClip moonFest;
    public AudioClip maple;
    public AudioClip crab;
    public AudioClip horse;
    public AudioClip bath;
    public AudioClip snow;
    public AudioClip coin;
    public AudioClip icecream;
    public AudioClip rain;
    public AudioClip surf;
    public AudioClip lantern;
    public AudioClip flower;
    private AudioSource audioS;

	// Use this for initialization
	void Start () {
        audioS = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void playLantern()
    {
        audioS.PlayOneShot(lantern);
    }

    void playFlower()
    {
        audioS.PlayOneShot(flower);
    }

    void playIcecream()
    {
        audioS.PlayOneShot(icecream);
    }

    void playRain()
    {
        audioS.PlayOneShot(rain);
    }

    void playSurf()
    {
        audioS.PlayOneShot(surf);
    }

    void playCoin()
    {
        audioS.PlayOneShot(coin);
    }

    void playSnow()
    {
        audioS.PlayOneShot(snow);
    }

    void playBath()
    {
        audioS.PlayOneShot(bath);
    }

    void playHorse()
    {
        audioS.PlayOneShot(horse);
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
