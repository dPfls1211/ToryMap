using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIExplain1 : MonoBehaviour
{
    VisualElement root;
    private Button enter_btn;
    private Button exit_btn;
    private Label text_label;
    private IMGUIContainer imgcontainer;


    void OnEnable()
    {
        Debug.Log(8);
        root = GetComponent<UIDocument>().rootVisualElement;
        enter_btn = root.Q<Button>("enter_btn");
        exit_btn = root.Q<Button>("exit_btn");
        enter_btn.clicked += enterclick;
        exit_btn.clicked += exitclick;
        exit_btn.RegisterCallback<ClickEvent>(exitclick);
        text_label = root.Q<Label>("Text_label");
        setexplain();
    }

    public void setexplain()
    {
        GameObject click = GameObject.Find(SetUIZoomObj.zoomInTargetObj.name);
        string explain = click.GetComponent<ObjSetUi>().objExplane;
        text_label.text = explain;

    }
    private void enterclick()
    {
        GetComponent<EnterBtnLoadScene>().onClickToURL();
    }

    private void exitclick()
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
