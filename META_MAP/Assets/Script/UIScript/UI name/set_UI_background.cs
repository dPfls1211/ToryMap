using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class set_UI_background : MonoBehaviour
{
    public TMP_Text text;
    UI_Type.type thistype;

    //List<float> KORtext_len;
    //List<float> ENGtext_len;
    float korlen = 0;
    float englen = 0;
    public static bool onekor = true;
    public static bool oneeng = true;
    // Start is called before the first frame update
    void Awake()
    {
        thistype = GetComponentInParent<UI_Type>().uitype;
    }
    void Start()
    {
        //resizeUI();
        firstmake();
    }
    public void resizeUI()
    {
        if (thistype == UI_Type.type.name)
        {
            if (languageChange.langsetting == 0 && oneeng)
            {
                firstmake();
            }
            else if (languageChange.langsetting == 1 && onekor)
            {
                firstmake();
            }
            else if (!oneeng && !onekor)
            {
                knowname();
            }
            else
            {
                name();
            }

        }
        if (thistype == UI_Type.type.explain)
        {
            explain();
        }
    }

    public void firstmake()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.preferredWidth * 1.2f);
        if (languageChange.langsetting == 0)
        {
            englen = text.preferredWidth;
        }
        if (languageChange.langsetting == 1)
        {
            korlen = text.preferredWidth;
        }
    }

    public void knowname()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        if (languageChange.langsetting == 0)
        {
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, englen * 1.2f);
        }
        if (languageChange.langsetting == 1)
        {
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, korlen * 1.2f);
        }


    }

    public void name()
    {

        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.preferredWidth * 1.2f);

        //ui name line생성시
        //        GameObject round = transform.GetChild(0).gameObject;
        //    GameObject linepivot = transform.GetChild(1).gameObject;
        //     round.GetComponent<RectTransform>().localPosition = new Vector3(rect.rect.width / 2, 0, 0);
        //    linepivot.GetComponent<RectTransform>().localPosition = new Vector3(rect.rect.width / 2, 0, 0);
    }
    void explain()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        float textcal = text.preferredHeight;
        if (text.preferredHeight > 180)
        {
            gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position.x, gameObject.transform.parent.transform.position.y + (text.preferredHeight - 180) * 0.05f, gameObject.transform.parent.transform.position.z);
        }
        rect.sizeDelta = new Vector2(300, textcal);

    }
}
