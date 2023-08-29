using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIExplain1 : MonoBehaviour
{
    VisualElement root;
    private Button enter_btn;
    private Button exit_btn;
    private Label text_label_content;
    private Label text_label_title;
    private IMGUIContainer imgcontainer;


    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        enter_btn = root.Q<Button>("enter_btn");
        exit_btn = root.Q<Button>("exit_btn");
        enter_btn.RegisterCallback<ClickEvent>(enterclick);
        exit_btn.RegisterCallback<ClickEvent>(exitclick);
        text_label_content = root.Q<Label>("Text_label-contents");
        text_label_title = root.Q<Label>("Text_label-title");
        setexplain();
    }

    public void setexplain()
    {
        GameObject click = GameObject.Find(SetUIZoomObj.zoomInTargetObj.name);
        string explain = click.GetComponent<ObjSetUi>().objExplane;
        text_label_content.text = explain;
        text_label_title.text = click.GetComponent<ObjSetUi>().objName;

    }
    // private void enterclick()
    // {
    //     GetComponent<EnterBtnLoadScene>().onClickToURL();
    // }
    private void enterclick(ClickEvent ev)
    {
        Debug.Log(9);
        GetComponent<EnterBtnLoadScene>().onClickToURL();
    }

    public void exitclick()
    {
        Debug.Log(9);
        GetComponentInParent<UIExplain_ver3>().infoOff();
        GameObject.Find("objImage_zoomExplane").GetComponent<SetUIZoomObj>().hiddenOBJView();
    }
    public void exitclick(ClickEvent ev)
    {
        Debug.Log(7);
        GetComponentInParent<UIExplain_ver3>().infoOff();
        GameObject.Find("objImage_zoomExplane").GetComponent<SetUIZoomObj>().hiddenOBJView();
    }
}
