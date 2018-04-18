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
    //private string url = "ftp://nccudct:macbook@140.119.138.83/";
    private string url = "D://strangeMan/";
    private string url1;
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
            url1 = url + "1.png";
            Debug.Log(url1);
            StartCoroutine(loadImage());
            
        }
            
    }

    IEnumerator loadImage()
    {
        Texture2D tex;
        WWW www;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        www = new WWW(url1);
        yield return www;
   
        //Debug.Log(www.error);
        if (www.error == "Unknown Error")
        {
            url1 = url + "2.png";
            Debug.Log(url1);
            tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            www = new WWW(url1);
            yield return www;

            if(www.error == "Unknown Error")
            {
                url1 = url + "3.png";
                tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                www = new WWW(url1);
                yield return www;

                if (www.error == "Unknown Error")
                {
                    url1 = url + "4.png";
                    tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                    www = new WWW(url1);
                    yield return www;

                    if (www.error == "Unknown Error")
                    {
                        url1 = url + "5.png";
                        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                        www = new WWW(url1);
                        yield return www;

                        if (www.error == "Unknown Error")
                        {
                            Debug.Log("??");
                        }
                        else
                        {
                            www.LoadImageIntoTexture(tex);
                            m = Instantiate(man5, new Vector3(0, 0, 80), Quaternion.identity);
                            anim = m.GetComponent<Animation>();
                            anim["man5"].wrapMode = WrapMode.Loop;
                            anim.PlayQueued("man5");
                        }
                    }
                    else
                    {
                        www.LoadImageIntoTexture(tex);
                        m = Instantiate(man4, new Vector3(0, 0, 80), Quaternion.identity);
                        anim = m.GetComponent<Animation>();
                        anim["man4"].wrapMode = WrapMode.Loop;
                        anim.PlayQueued("man4");
                    }
                }
                else
                {
                    www.LoadImageIntoTexture(tex);
                    m = Instantiate(man3, new Vector3(0, 0, 80), Quaternion.identity);
                    anim = m.GetComponent<Animation>();
                    anim["man3"].wrapMode = WrapMode.Loop;
                    anim.PlayQueued("man3");
                }
            }
            else
            {
                www.LoadImageIntoTexture(tex);
                m = Instantiate(man2, new Vector3(0, 0, 80), Quaternion.identity);
                anim = m.GetComponent<Animation>();
                anim["man2"].wrapMode = WrapMode.Loop;
                anim.PlayQueued("man2");
            }
        }
        else
        {
            www.LoadImageIntoTexture(tex);
            m = Instantiate(man1, new Vector3(0, 0, 80), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man1"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man1");
        }

        /*
        www.LoadImageIntoTexture(tex);

        if (manNumber == 1)
        {
            m = Instantiate(man1, new Vector3(0, 0, -1), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man1"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man1");
        }
        else if (manNumber == 2)
        {
            m = Instantiate(man2, new Vector3(0, 0, -1), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man2"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man2");
        }
        else if (manNumber == 3)
        {
            m = Instantiate(man3, new Vector3(0, 0, -1), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man3"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man3");
        }
        else if (manNumber == 4)
        {
            m = Instantiate(man4, new Vector3(0, 0, -1), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man4"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man4");
        }
        else if (manNumber == 5)
        {
            m = Instantiate(man5, new Vector3(0, 0, -1), Quaternion.identity);
            anim = m.GetComponent<Animation>();
            anim["man5"].wrapMode = WrapMode.Loop;
            anim.PlayQueued("man5");
            manNumber = 0;
        }
       */

        body = m.transform.Find("body").gameObject;

        Rect rec = new Rect(0, 0, tex.width, tex.height);
        Sprite s = Sprite.Create(tex, rec, new Vector2(0, 0), 1);
        body.GetComponent<Image>().sprite = s;
        manNumber++;
    }

}
