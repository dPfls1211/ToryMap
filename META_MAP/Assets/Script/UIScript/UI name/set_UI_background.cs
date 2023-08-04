using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class set_UI_background : MonoBehaviour
{
    public TMP_Text text;
    UI_Type.type thistype;
    // Start is called before the first frame update
    void Awake()
    {
        thistype = GetComponentInParent<UI_Type>().uitype;
    }
    void Start()
    {
        resizeUI();
    }
    public void resizeUI()
    {
        if (thistype == UI_Type.type.name)
        {
            name();
        }
        if (thistype == UI_Type.type.explain)
        {
            explain();
        }
    }
    public void name()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.preferredWidth * 1f);

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
