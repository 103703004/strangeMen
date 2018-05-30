using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FluentFTP;
using System;
using System.Threading;

public class createMan : MonoBehaviour
{

    public GameObject man1;
    public GameObject man2;
    public GameObject man3;
    public GameObject man4;
    public GameObject man5;
    private GameObject body;
    private GameObject m;
    //private string url = "ftp://nccudct:macbook@140.119.138.83/";
    //private string url = "D://strangeMan/";
    //private string url1;
    public static int manNumber;
    private Animation anim;
    private int count;
    private int MAX_MAN_NUMBER;

    GameObject[] menObjects = {};

    string[] manKind = { "1.png", "2.png", "3.png", "4.png", "5.png" };
    string[] manName = { "man1", "man2", "man3", "man4", "man5" };

    FtpClient client = new FtpClient("140.119.138.83", "nccudct", "macbook"); // or set Host & Credentials
    int interval = 5;
    float nextTime = 0;

    int loadInterval = 1;
    float loadNextTime = 0;

    // Use this for initialization
    void Start()
    {
        count = 0;
        MAX_MAN_NUMBER = 5;

        //manNumber = 1;
        menObjects = new GameObject[] { man1, man2, man3, man4, man5 };

        // begin connecting to the server
        client.Connect();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextTime)
        {
            nextTime += interval;
            Thread t = new Thread(new ThreadStart(downloadImg));
            t.Start();
            //StartCoroutine(LoadMan());
            //loadMen();
        }

        if (Time.time >= loadNextTime)
        {
            loadNextTime += loadInterval;
            //Thread t = new Thread(new ThreadStart(downloadImg));
            //t.Start();
            //StartCoroutine(LoadMan());
            loadMen();
        }

        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         //body = m.transform.Find("body").gameObject;
        //         //Debug.Log("space key was pressed");
        //         //url1 = url + "1.png";
        //         //Debug.Log(url1);

        //         Thread t = new Thread(new ThreadStart(downloadImg));
        //         t.Start();

        //   //StartCoroutine(LoadMan());
        //loadMen();
        //}
    }


    void loadMen()
    {
        Texture2D tex = null;
        byte[] fileData;

        foreach (var man in manKind)
        {
            if (File.Exists("img/" + man))
            {

                int ManIndex = Array.IndexOf(manKind, man);

                //Debug.Log(man);
                //Debug.Log(ManIndex);

                try
                {
                    fileData = File.ReadAllBytes("img/" + man);
                    tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                    tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.


                    m = Instantiate(menObjects[ManIndex], new Vector3(0, 0, 80), Quaternion.identity);
                    anim = m.GetComponent<Animation>();
                    anim[manName[ManIndex]].wrapMode = WrapMode.Loop;
                    anim.PlayQueued(manName[ManIndex]);

                    count++;
                    m.GetComponent<move>().sequence = count;

                    if(count > MAX_MAN_NUMBER)
                    {
                        var man1 = GameObject.FindGameObjectsWithTag("man1");
                        var man2 = GameObject.FindGameObjectsWithTag("man2");
                        var man3 = GameObject.FindGameObjectsWithTag("man3");
                        var man4 = GameObject.FindGameObjectsWithTag("man4");
                        var man5 = GameObject.FindGameObjectsWithTag("man5");

                        
                        foreach (GameObject myMan in man1)
                        {
                            if (myMan.GetComponent<move>().sequence <= count - MAX_MAN_NUMBER)
                            {
                                Destroy(myMan);
                            }
                        }
                        foreach (GameObject myMan in man2)
                        {
                            if (myMan.GetComponent<move>().sequence <= count - MAX_MAN_NUMBER)
                            {
                                Destroy(myMan);
                            }
                        }
                        foreach (GameObject myMan in man3)
                        {
                            if (myMan.GetComponent<move>().sequence <= count - MAX_MAN_NUMBER)
                            {
                                Destroy(myMan);
                            }
                        }
                        foreach (GameObject myMan in man4)
                        {
                            if (myMan.GetComponent<move>().sequence <= count - MAX_MAN_NUMBER)
                            {
                                Destroy(myMan);
                            }
                        }
                        foreach (GameObject myMan in man5)
                        {
                            if (myMan.GetComponent<move>().sequence <= count - MAX_MAN_NUMBER)
                            {
                                Destroy(myMan);
                            }
                        }
                    }

                    body = m.transform.Find("body").gameObject;
                    Rect rec = new Rect(0, 0, tex.width, tex.height);
                    Sprite s = Sprite.Create(tex, rec, new Vector2(0, 0), 1);
                    body.GetComponent<Image>().sprite = s;

                    //File.Delete("img/" + man);
                    File.Move("img/" + man, "img/" + man + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");

                }
                catch (System.Exception e)
                {
                    Debug.LogWarning(e);
                }

                break;
            }
        }
    }


   /* IEnumerator LoadMan()
    {

        Texture2D tex = null;
        byte[] fileData;
        yield return null;

        foreach (var man in manKind)
        {
            int ManIndex = Array.IndexOf(manKind, man) + 1;

            if (File.Exists("img/" + man))
            {
                fileData = File.ReadAllBytes("img/" + man);
                tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.

                //File.Delete("img/" + man);

                m = Instantiate(man1, new Vector3(0, 0, 80), Quaternion.identity);
                anim = m.GetComponent<Animation>();
                anim["man" + ManIndex].wrapMode = WrapMode.Loop;
                anim.PlayQueued("man" + ManIndex);

                body = m.transform.Find("body").gameObject;
                Rect rec = new Rect(0, 0, tex.width, tex.height);
                Sprite s = Sprite.Create(tex, rec, new Vector2(0, 0), 1);
                body.GetComponent<Image>().sprite = s;

                break;
            }
        }
    }*/

    void downloadImg()
    {

        // begin connecting to the server
        //client.Connect();

        foreach (var man in manKind)
        {

            // check if a file exists
            if (client.FileExists("strangMen/" + man))
            {

                Progress<double> progress = new Progress<double>(x => {
                    // When progress in unknown, -1 will be sent
                    if (x >= 100)
                    {
                        // delete the file
                        //client.DeleteFile("strangMen/" + man);
                        client.Rename("strangMen/" + man, "strangMen/" + man + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");

                        //client.Disconnect();
                        return;
                    }
                });

                client.DownloadFile(@"img/" + man, "strangMen/" + man, true, FluentFTP.FtpVerify.Retry, progress);
                break;
            }
        }
    }

    //IEnumerator loadImage()
    //{
    //    Texture2D tex;
    //    WWW www;
    //    tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
    //    www = new WWW(url1);
    //    yield return www;


    //    Debug.Log(www.error);
    //    if (www.error == "Unknown Error")
    //    {
    //        url1 = url + "2.png";
    //        Debug.Log(url1);
    //        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
    //        www = new WWW(url1);
    //        yield return www;

    //        if(www.error == "Unknown Error")
    //        {
    //            url1 = url + "3.png";
    //            tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
    //            www = new WWW(url1);
    //            yield return www;

    //            if (www.error == "Unknown Error")
    //            {
    //                url1 = url + "4.png";
    //                tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
    //                www = new WWW(url1);
    //                yield return www;

    //                if (www.error == "Unknown Error")
    //                {
    //                    url1 = url + "5.png";
    //                    tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
    //                    www = new WWW(url1);
    //                    yield return www;

    //                    if (www.error == "Unknown Error")
    //                    {
    //                        Debug.Log("??");
    //                    }
    //                    else
    //                    {
    //                        www.LoadImageIntoTexture(tex);
    //                        m = Instantiate(man5, new Vector3(0, 0, 80), Quaternion.identity);
    //                        anim = m.GetComponent<Animation>();
    //                        anim["man5"].wrapMode = WrapMode.Loop;
    //                        anim.PlayQueued("man5");
    //                    }
    //                }
    //                else
    //                {
    //                    www.LoadImageIntoTexture(tex);
    //                    m = Instantiate(man4, new Vector3(0, 0, 80), Quaternion.identity);
    //                    anim = m.GetComponent<Animation>();
    //                    anim["man4"].wrapMode = WrapMode.Loop;
    //                    anim.PlayQueued("man4");
    //                }
    //            }
    //            else
    //            {
    //                www.LoadImageIntoTexture(tex);
    //                m = Instantiate(man3, new Vector3(0, 0, 80), Quaternion.identity);
    //                anim = m.GetComponent<Animation>();
    //                anim["man3"].wrapMode = WrapMode.Loop;
    //                anim.PlayQueued("man3");
    //            }
    //        }
    //        else
    //        {
    //            www.LoadImageIntoTexture(tex);
    //            m = Instantiate(man2, new Vector3(0, 0, 80), Quaternion.identity);
    //            anim = m.GetComponent<Animation>();
    //            anim["man2"].wrapMode = WrapMode.Loop;
    //            anim.PlayQueued("man2");
    //        }
    //    }
    //    else
    //    {
    //        www.LoadImageIntoTexture(tex);
    //        m = Instantiate(man1, new Vector3(0, 0, 80), Quaternion.identity);
    //        anim = m.GetComponent<Animation>();
    //        anim["man1"].wrapMode = WrapMode.Loop;
    //        anim.PlayQueued("man1");
    //    }

    //    /*
    //    www.LoadImageIntoTexture(tex);

    //    if (manNumber == 1)
    //    {
    //        m = Instantiate(man1, new Vector3(0, 0, -1), Quaternion.identity);
    //        anim = m.GetComponent<Animation>();
    //        anim["man1"].wrapMode = WrapMode.Loop;
    //        anim.PlayQueued("man1");
    //    }
    //    else if (manNumber == 2)
    //    {
    //        m = Instantiate(man2, new Vector3(0, 0, -1), Quaternion.identity);
    //        anim = m.GetComponent<Animation>();
    //        anim["man2"].wrapMode = WrapMode.Loop;
    //        anim.PlayQueued("man2");
    //    }
    //    else if (manNumber == 3)
    //    {
    //        m = Instantiate(man3, new Vector3(0, 0, -1), Quaternion.identity);
    //        anim = m.GetComponent<Animation>();
    //        anim["man3"].wrapMode = WrapMode.Loop;
    //        anim.PlayQueued("man3");
    //    }
    //    else if (manNumber == 4)
    //    {
    //        m = Instantiate(man4, new Vector3(0, 0, -1), Quaternion.identity);
    //        anim = m.GetComponent<Animation>();
    //        anim["man4"].wrapMode = WrapMode.Loop;
    //        anim.PlayQueued("man4");
    //    }
    //    else if (manNumber == 5)
    //    {
    //        m = Instantiate(man5, new Vector3(0, 0, -1), Quaternion.identity);
    //        anim = m.GetComponent<Animation>();
    //        anim["man5"].wrapMode = WrapMode.Loop;
    //        anim.PlayQueued("man5");
    //        manNumber = 0;
    //    }
    //   */

    //    body = m.transform.Find("body").gameObject;

    //    Rect rec = new Rect(0, 0, tex.width, tex.height);
    //    Sprite s = Sprite.Create(tex, rec, new Vector2(0, 0), 1);
    //    body.GetComponent<Image>().sprite = s;
    //    manNumber++;
    //}

}
