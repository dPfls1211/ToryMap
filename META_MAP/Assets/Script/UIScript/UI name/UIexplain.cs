using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UIexplain : MonoBehaviour
{
    GameObject explain;
    GameObject[] childlist;

    GameObject camera;

    GameObject onExplain;
    GameObject onEnterIcon;

    string name;


    [NonSerialized]
    public bool objON = false;
    public bool followOn = false;

    public GameObject UI_Explain;
    public GameObject UI_entericon;
    GameObject click;

    Camera cam;

    followObj followobj;
    // Start is called before the first frame update
    void Start()
    {
        followobj = GameObject.Find("UI_NAME_Canvas").GetComponent<followObj>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followOn)
        {
            follow();
        }
    }


    public void canvasOff()
    {
        Destroy(onExplain);
        Destroy(onEnterIcon);
        followobj.namechangepos = false;
        followobj.namemove();
        followOn = false;

    }
    public void clickObj(GameObject obj)
    {
        click = obj;
        followobj.namechangepos = true;
        followobj.namemove();
        CreateExplainPanel(obj);
        createEnterIcon(obj);
    }

    void CreateExplainPanel(GameObject objclick)
    {
        onExplain = Instantiate(UI_Explain);
        onExplain.transform.SetParent(transform, true);
        onExplain.transform.position = new Vector3(objclick.transform.position.x, objclick.transform.position.y + 6.0f, objclick.transform.position.z);

        if (objclick.transform.GetComponent<ObjSetUi>().objExplane == null)
        {
            onExplain.GetComponentInChildren<TMP_Text>().text = "정보 없음";
        }
        else
        {
            onExplain.GetComponentInChildren<TMP_Text>().text = objclick.transform.GetComponent<ObjSetUi>().objExplane;
            //explainPos = ins.transform;
        }
    }

    void createEnterIcon(GameObject objclick)
    {
        onEnterIcon = Instantiate(UI_entericon);
        onEnterIcon.transform.SetParent(transform, true);
        onEnterIcon.transform.position = new Vector3(objclick.transform.position.x, objclick.transform.position.y + 1.5f, objclick.transform.position.z);


    }
    void follow()
    {
        onExplain.transform.position = cam.WorldToScreenPoint(new Vector3(click.transform.position.x, click.transform.position.y + 6.0f, click.transform.position.z));
        onEnterIcon.transform.position = cam.WorldToScreenPoint(new Vector3(click.transform.position.x, click.transform.position.y + 1.5f, click.transform.position.z));

    }
}
