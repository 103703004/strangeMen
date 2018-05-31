using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class press : MonoBehaviour {

    private Animation anim;
    private string manNumber;
    public bool isPress;
    public Sprite springBud;
    public Sprite springLantern;
    public Sprite springWreath;
    public Sprite summerIceCream;
    public Sprite summerRainy;
    public Sprite summerSurf;
    public Sprite fallCrab;
    public Sprite fallMaple;
    public Sprite fallMoon;
    public Sprite winterBath;
    public Sprite winterDeer;
    public Sprite winterSnowMan;
    private float t1, t2, t3;
    private bool b;
    //public Text text;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        manNumber = tag;
        isPress = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && b)
        {
            t3 = Time.realtimeSinceStartup;
            if (t3 - t2 < 0.2)
            {
                if (t2 - t1 < 0.2)
                {
                    print("triple click");
                    Destroy(this.gameObject);
                }
                t1 = t2;
            }
            t2 = t3;
            
        }
    }

    void OnMouseEnter()
    {
        b = true;
    }
    void OnMouseExit()
    {
        b = false;
    }

    void OnMouseDown()
    {
        //text.text = gameObject.transform.position.x + " " + gameObject.transform.position.y;
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
            Debug.Log(gameObject.GetComponent<move>().sequence);

            if (seasonChange.season.Equals("spring"))
            {
                gameObject.transform.Find("menu/menu1").gameObject.GetComponent<Image>().sprite = springBud;
                gameObject.transform.Find("menu/menu2").gameObject.GetComponent<Image>().sprite = springLantern;
                gameObject.transform.Find("menu/menu3").gameObject.GetComponent<Image>().sprite = springWreath;
            }
            else if (seasonChange.season.Equals("summer"))
            {
                gameObject.transform.Find("menu/menu1").gameObject.GetComponent<Image>().sprite = summerIceCream;
                gameObject.transform.Find("menu/menu2").gameObject.GetComponent<Image>().sprite = summerSurf;
                gameObject.transform.Find("menu/menu3").gameObject.GetComponent<Image>().sprite = summerRainy;
            }
            else if (seasonChange.season.Equals("fall"))
            {
                gameObject.transform.Find("menu/menu1").gameObject.GetComponent<Image>().sprite = fallMoon;
                gameObject.transform.Find("menu/menu2").gameObject.GetComponent<Image>().sprite = fallMaple;
                gameObject.transform.Find("menu/menu3").gameObject.GetComponent<Image>().sprite = fallCrab;
            }
            else if (seasonChange.season.Equals("winter"))
            {
                gameObject.transform.Find("menu/menu1").gameObject.GetComponent<Image>().sprite = winterBath;
                gameObject.transform.Find("menu/menu2").gameObject.GetComponent<Image>().sprite = winterSnowMan;
                gameObject.transform.Find("menu/menu3").gameObject.GetComponent<Image>().sprite = winterDeer;
            }

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
