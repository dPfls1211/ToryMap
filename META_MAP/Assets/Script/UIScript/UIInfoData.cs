using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UIInfoData : MonoBehaviour
{
    /// 변수. 파일명, 객체 이름, 전후 변수, //적용, 취소 고려  



    public CMS_TYPES.CMSType cmstype;                 //CMS 장면이 어떤 타입인지...
    public CMS_TYPES.CMSUIType cmsUIType;             //해당 UI 타입
    public CMS_TYPES.CMSOBJType cmsObjtype;           //해당 객체가 UIToolkit인지 판단

    public string ChangefileContentsUI;     //해당 UI 소스의 파일 이름명 (변경될 예정)
    public string OriginfileContentsUI;     //해당 UI 소스의 파일 이름명 (기존)
    public Texture2D changeFileContentsUIImg;




    //로딩씬일때, 아닐때 if문 다음. 타입별 if문
    public void setChangedUI(string _text)
    {
        if (cmstype == CMS_TYPES.CMSType.cms_loading)
        {
            SetLoadingCms(_text);
        }
    }

    public void setChangedUI(Sprite _img)
    {
        if (cmstype == CMS_TYPES.CMSType.cms_loading)
        {
            SetLoadingCms(_img);
        }
    }

    public void setChangedUI()
    {
    }

    //로딩씬 설정
    private void SetLoadingCms(string _text_)
    {
        var root = gameObject.GetComponent<UIDocument>().rootVisualElement;

        GetComponent<loadingToolkit>().set_text = _text_;

        root.Q<Label>("infotext").text = _text_;
        //Debug.Log("setLoading");
    }
    private void SetLoadingCms(Sprite _img_)
    {
        var root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        Debug.Log(_img_.name);

        GetComponent<loadingToolkit>().set_img = new StyleBackground(_img_);
        root.Q<VisualElement>("Loading_logo").style.backgroundImage = new StyleBackground(_img_);
        //root.Q<VisualElement>("Loading_logo").style.backgroundImage = changeFileContentsUIImg;
        Debug.Log("setLoading");
    }

    private void setUIImgSource()  //
    {
        // gameObject.GetComponent<>()
    }

    ///이미지 지금 갖고있는 스크립트 따로 만들기,


    /// 적용하는 함수 전체 함수 만들어서 if문으로 나누기
    /// 텍스트, 이미지, 동영상 url 
    /// 각자 타입에 따라 적용하는 함수 만들기
    /// 
    ///CMS에선 ChangefileNameUI로 보여줘야함.
}
