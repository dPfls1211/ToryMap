using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIVisible : MonoBehaviour
{
    public static string explaneUrl = "http://unity3d.com/";
    public string OBJname = "노강서원";
    public string objExplane_ = "조선 숙종 15년, 인현왕후 폐출을 반대하며 죽음으로써 간언하였던 정재 박태보의 뜻을 기리기 위하여 숙종 21년에 건립한 서원이다.";
    public string AssetAddress = "경기도 의정부시 동일로122번길 153(장암동)";
    public string phoneNum = "031 - 123 - 456";

    public TMP_Text ObjNameText;
    public TMP_Text objExplaneText;
    public TMP_Text AssetAddressText;
    public TMP_Text phoneNumText;


    public void UIUnVisible()
    {
        gameObject.SetActive(false);
    }

    public void UIUnVisible_can()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void OpenUrlUI()
    {
        //Debug.Log(explaneUrl);
        Application.OpenURL(explaneUrl);
    }

    public void SetUICan()
    {
        ObjNameText.text = OBJname;
        objExplaneText.text = objExplane_;
        AssetAddressText.text = AssetAddress;
        phoneNumText.text = phoneNum;
    }
}
