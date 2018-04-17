using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickMenu : MonoBehaviour {

    private Animation anim;
    private string manNumber;

	// Use this for initialization
	void Start () {
        anim = transform.parent.transform.parent.GetComponent<Animation>();
        manNumber = transform.parent.transform.parent.tag;
        //Debug.Log(manNumber);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void menu1()
    {
        if (seasonChange.season.Equals("spring"))
        {
            //TODO 發芽 春
            manyAnim("treeAnimation");
            //anim.PlayQueued("treeAnimation");
        }
        else if (seasonChange.season.Equals("summer"))
        {
            //TODO 冰淇淋 夏
			anim.PlayQueued("icecreamAnimation");
        }
        else if (seasonChange.season.Equals("fall"))
        {
            //TODO 中秋 秋
			//anim.PlayQueued("MoonFestival");//MoonFestival1;MoonFestival2;MoonFestival3;MoonFestival4;MoonFestival5
            manyAnim("MoonFestival");
        }
        else if (seasonChange.season.Equals("winter"))
        {
            //TODO 泡澡 冬
            anim.PlayQueued("bath");
        }

        StartAnimMain();

        gameObject.transform.parent.transform.parent.GetComponent<press>().isPress = false;
        transform.parent.gameObject.SetActive(false);
    }

    public void menu2()
    {
        if (seasonChange.season.Equals("spring"))
        {
            //TODO 天燈 春
            anim.PlayQueued("lantern");
        }
        else if (seasonChange.season.Equals("summer"))
        {
            //TODO 衝浪 夏
            manyAnim("surf");
        }
        else if (seasonChange.season.Equals("fall"))
        {
            //TODO 落葉 秋
            anim.PlayQueued("maple");
        }
        else if (seasonChange.season.Equals("winter"))
        {
            //TODO 雪人 冬
			anim.PlayQueued("snowAnimation");
        }

        StartAnimMain();

        gameObject.transform.parent.transform.parent.GetComponent<press>().isPress = false;
        transform.parent.gameObject.SetActive(false);
    }

    public void menu3()
    {
        if (seasonChange.season.Equals("spring"))
        {
            //TODO 花圈 春
            anim.PlayQueued("dropWreath");
        }
        else if (seasonChange.season.Equals("summer"))
        {
            //TODO 雨 夏
            //anim.PlayQueued("dropWreath");
        }
        else if (seasonChange.season.Equals("fall"))
        {
            //TODO 螃蟹 秋
            anim.PlayQueued("crabAnimation");
        }
        else if (seasonChange.season.Equals("winter"))
        {
            //TODO 鹿 冬
            anim.PlayQueued("deer");
        }

        StartAnimMain();

        gameObject.transform.parent.transform.parent.GetComponent<press>().isPress = false;
        transform.parent.gameObject.SetActive(false);
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
        transform.parent.transform.parent.gameObject.GetComponent<move>().isMove = true;
    }

    private void manyAnim(string name)
    {
        if (manNumber.Equals("man1"))
        {
            anim.PlayQueued(name + "1");
        }
        else if (manNumber.Equals("man2"))
        {
            anim.PlayQueued(name + "2");
        }
        else if (manNumber.Equals("man3"))
        {
            anim.PlayQueued(name + "3");
        }
        else if (manNumber.Equals("man4"))
        {
            anim.PlayQueued(name + "4");
        }
        else if (manNumber.Equals("man5"))
        {
            anim.PlayQueued(name + "5");
        }
    }
}
