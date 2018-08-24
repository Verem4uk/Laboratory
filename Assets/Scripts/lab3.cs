using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lab3 : MonoBehaviour {

    public Image spectr;
    public Image Count;
    public int newpos = 0;
    public float oldpos = 0;
    public bool movet = false;
    public Text text;

    public Sprite a1;
    public Sprite a2;
    public Sprite a3;
    public Sprite a4;
    public Sprite a5;
    public Sprite a6;
    public Sprite a7;
    public Sprite a8;
    public Sprite a9;



    private void Start()
    {
        Vector3 pos = spectr.transform.localPosition;
        oldpos = pos.x;
    }

    void Update ()
    {
        if (movet)
        {
            if (oldpos < newpos)
            {
                oldpos+=2;
            }
            if (oldpos > newpos)
            {
                oldpos-=2;
            }
            Vector3 pos = spectr.transform.localPosition;
            pos.x = oldpos;
            spectr.transform.localPosition = pos;
            if (oldpos == newpos) movet = false;
        }

    }

    public void ClickRight()
    {        
        float oldpos = spectr.transform.localPosition.x;
        if (oldpos == 700) newpos = 618;
        if (oldpos == 618) newpos = 382;
        if (oldpos == 382) newpos = 316;
        if (oldpos == 316) newpos = 48;
        if (oldpos == 48) newpos = -266;
        if (oldpos == -266) newpos = -384;
        if (oldpos == -384) newpos = -638;
        if (oldpos == -638) newpos = -712;        
        if (oldpos != newpos) movet = true;
    }
    public void ClickLeft()
    {
        float oldpos = spectr.transform.localPosition.x;
        if (oldpos == 618) newpos = 700;
        if (oldpos == 382) newpos = 618;
        if (oldpos == 316) newpos = 382;
        if (oldpos == 48) newpos = 316;
        if (oldpos == -266) newpos = 48;
        if (oldpos == -384) newpos = -266;
        if (oldpos == -638) newpos = -384;
        if (oldpos == -712) newpos = -638;
        if (oldpos != newpos) movet = true;
    }
    public void ClickCount()
    {
        var picture = Count.GetComponent<Image>();
        if (oldpos == 700)
        {
            text.text = "109°59′24″";
            picture.sprite = a1;
        }
        if (oldpos == 618)
        {
            text.text = "110°07′48″";
            picture.sprite = a2;
        }
        if (oldpos == 382)
        {
            text.text = "110°23′24″";
            picture.sprite = a3;
        }
        if (oldpos == 316)
        {
            text.text = "110°25′12″";
            picture.sprite = a4;
        }
        if (oldpos == 48)
        {
            text.text = "110°46′12″";
            picture.sprite = a5;
        }
        if (oldpos == -266)
        {
            text.text = "111°34′48″";
            picture.sprite = a6;
        }
        if (oldpos == -384)
        {
            text.text = "112°50′24″";
            picture.sprite = a7;
        }
        if (oldpos == -638)
        {
            text.text = "113°44′24″";
            picture.sprite = a8;
        }
        if (oldpos == -712)
        {
            text.text = "113°51′0″";
            picture.sprite = a9;
        }
        //print.oldpos;
        //Count.GetComponent<Image>() = picture;
    }
}
