using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExplain_ver3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIExplain3;

    GameObject clickobj;
    GameObject clickChildobj;
    MainCamera_Action main;

    UIName uiname;

    public GameObject inforound;
    string clickedUIColor = "#283968";
    string UnClickedUIColor = "#000000";

    GameObject Ui_info_toolkit;

    void Awake()
    {
        Ui_info_toolkit = GameObject.Find("info_toolkit").transform.GetChild(0).transform.gameObject;
        uiname = GameObject.Find("GameObject").GetComponent<UIName>();
        main = GameObject.Find("Main Camera").GetComponent<MainCamera_Action>();
    }

    public void click(GameObject obj)
    {
        // UIExplain3.SetActive(true);
        //Ui_info_toolkit.SetActive(true);
        clickobj = obj;

        findNameui();
    }

    public void infoOff()
    {
        //UIExplain3.SetActive(false);
        Ui_info_toolkit.SetActive(false);
        // Color color;
        // ColorUtility.TryParseHtmlString(UnClickedUIColor, out color);
        // color.a = 0.4f;
        // clickChildobj.GetComponentInChildren<Image>().color = color;
        //        clickChildobj.transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(false);
        //       clickChildobj.transform.GetChild(0).transform.GetChild(1).transform.gameObject.SetActive(false);

        main.resetZoom();


    }
    void findNameui()
    {
        for (int i = 0; i < uiname.objlen; i++)
        {
            if (uiname.UI_child_list[i].name == clickobj.name)
            {
                clickChildobj = uiname.UI_child_list[i];
                // Color color;
                // ColorUtility.TryParseHtmlString(clickedUIColor, out color);
                // color.a = 0.9f;
                // uiname.UI_child_list[i].GetComponentInChildren<Image>().color = color;
                //lineWidth();
                break;
            }
        }
    }

    //ui_name line 생성 스크립트
    void lineWidth()
    {
        clickChildobj.transform.GetChild(0).transform.GetChild(0).transform.gameObject.SetActive(true);
        clickChildobj.transform.GetChild(0).transform.GetChild(1).transform.gameObject.SetActive(true);

        float inforoundx = inforound.transform.localPosition.x;

        GameObject roung_img = clickChildobj.transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        float width = inforoundx - roung_img.transform.localPosition.x;

        GameObject line = clickChildobj.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).transform.gameObject;
        line.GetComponent<RectTransform>().sizeDelta = new Vector2(width - 71.915f, line.GetComponent<RectTransform>().rect.height);

    }





}
