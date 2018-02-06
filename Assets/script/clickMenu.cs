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
        //TODO 發芽 春
        //anim.PlayQueued("dropWreath");

        //TODO 冰淇淋 夏
        //anim.PlayQueued("dropWreath");

        //TODO 中秋 秋
        //anim.PlayQueued("dropWreath");

        //TODO 泡澡 冬
        //anim.PlayQueued("dropWreath");

        StartAnimMain();

        gameObject.GetComponent<press>().isPress = false;
        transform.parent.gameObject.SetActive(false);
    }

    public void menu2()
    {
        //TODO 天燈 春
        //anim.PlayQueued("dropWreath");

        //TODO 衝浪 夏
        //anim.PlayQueued("dropWreath");

        //TODO 落葉 秋
        //anim.PlayQueued("dropWreath");

        //TODO 雪人 冬
        //anim.PlayQueued("dropWreath");

        StartAnimMain();

        gameObject.GetComponent<press>().isPress = false;
        transform.parent.gameObject.SetActive(false);
    }

    public void menu3()
    {
        //TODO 花圈 春
        anim.PlayQueued("dropWreath");

        //TODO 雨 夏
        //anim.PlayQueued("dropWreath");

        //TODO 螃蟹 秋
        //anim.PlayQueued("dropWreath");

        //TODO 鹿 冬
        //anim.PlayQueued("dropWreath");

        StartAnimMain();

        gameObject.GetComponent<press>().isPress = false;
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
}
