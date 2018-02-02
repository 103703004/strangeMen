using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createMan : MonoBehaviour {

    public GameObject man1;
    public GameObject man2;
    public GameObject man3;
    public GameObject man4;
    public GameObject man5;
    private GameObject body;
    private GameObject m;
    private string url = "D://政大/數位內容畢製/body/1.png";
    //private string url = "https://firebasestorage.googleapis.com/v0/b/webfinal-e58b9.appspot.com/o/%E5%83%91%E7%B7%A3.jpg?alt=media&token=f7634a76-4b94-4ac1-b57c-80f5eaaa0e4f";
    public static int manNumber;
    private Animation anim;

    // Use this for initialization
    void Start () {
        manNumber = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //body = m.transform.Find("body").gameObject;
            Debug.Log("space key was pressed");
            StartCoroutine(loadImage());
            
        }
            
    }

    IEnumerator loadImage()
    {
        Texture2D tex;
        WWW www;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(tex);

        if (manNumber == 1)
        {
            m = Instantiate(man1, new Vector3(0, 0, 90), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man1"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man1");
        }
        else if (manNumber == 2)
        {
            m = Instantiate(man2, new Vector3(0, 0, 90), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man2"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man2");
        }
        else if (manNumber == 3)
        {
            m = Instantiate(man3, new Vector3(0, 0, 90), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man3"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man3");
        }
        else if (manNumber == 4)
        {
            m = Instantiate(man4, new Vector3(0, 0, 90), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man4"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man4");
        }
        else if (manNumber == 5)
        {
            m = Instantiate(man5, new Vector3(0, 0, 90), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man5"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man5");
            manNumber = 0;
        }

        body = m.transform.Find("body").gameObject;

        Rect rec = new Rect(0, 0, tex.width, tex.height);
        Sprite s = Sprite.Create(tex, rec, new Vector2(0, 0), 1);
        //body.GetComponent<Image>().sprite = s;
        manNumber++;
    }
}
