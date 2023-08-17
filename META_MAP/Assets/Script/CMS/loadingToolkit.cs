using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UIElements;

public class loadingToolkit : MonoBehaviour
{

    /// origin setting 
    private StyleBackground logoImg;
    private string VideoUrl;
    private string Text;

    public VisualTreeAsset rowContents_loading;

    private string[] loadingNames = { "Loading_logo", "Loading_video", "infotext" };

    private string[] Sizeinfo = { "(png, jpg, jpeg 지원, 권장 사이즈 - 900*600 / 500KB)", "(mp4 및 영상 링크 지원, 권장 사이즈 - 1280*720 / 500KB)" };
    private string[] contents = { "상단 로고", "의정부 리버사이드.png", "로딩 영상", "의정부 리버사이드.mp4", "소개 문구", "의정부 리버사이드에 오신 것을 환영합니다. 저희가 제공하는 가상 스테이지에서 지역 서비스를 경험하며, 즐거운 시간 보내시길 바랍니다." };
    public Texture2D[] Toggle_img = new Texture2D[2];

    //change setting
    public StyleBackground set_img;
    public string set_text;
    public string set_url;

    //private VisualElement 
    private VisualElement Loading_logo;
    private Label Loading_infotxt;
    private VideoPlayer Loading_videoUrl;
    int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var i in loadingNames)
        {
            createloadingTableRow(i);
        }

        var root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        Loading_logo = root.Q<VisualElement>("Loading_logo");
        Loading_infotxt = root.Q<Label>("infotext");
        Loading_videoUrl = GameObject.Find("VideoPlayer").transform.GetComponent<VideoPlayer>();

        set_img = logoImg = Loading_logo.style.backgroundImage;
        set_url = VideoUrl = Loading_videoUrl.url;
        set_text = Text = Loading_infotxt.text;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setText(string _text)
    {
        set_text = _text;
    }

    public void setimg(Texture2D _img)
    {
        set_img = _img;
    }
    private void createloadingTableRow(string name)
    {
        var root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        root.Q<VisualElement>("TableVisual").Add(rowContents_loading.Instantiate());


        VisualElement contents_ = root.Q("tableRowContents");
        contents_.name = "tableRowContents_" + name.ToString();

        contents_.Q<Label>("itemBoxName").text = contents[inputIndex++];
        contents_.Q<Label>("fileBoxTitleName").text = contents[inputIndex++];

        if (name.Equals("infotext"))
        {
            contents_.Q<Label>("guideText").style.display = DisplayStyle.None;
        }
        else
        {
            contents_.Q<Label>("fileBoxTitleName").style.marginRight = 0;
            contents_.Q<Label>("guideText").text = Sizeinfo[inputIndex / 2 - 1];
        }

        contents_.Q<Toggle>("check_toggle").RegisterValueChangedCallback(OnCheckedEvent);
        //contents_.Q<Toggle>("check_toggle").RegisterCallback<ClickEvent>(OnBtnClickedEvent);
        contents_.Q<Toggle>("check_toggle").name = name;
        contents_.Q("changeBtnName").RegisterCallback<ClickEvent>(OnBtnClickedEvent);
        contents_.Q("changeBtnName").name = "changeBtnName-" + name.ToString();

    }


    //체크버튼 클릭시
    private void OnCheckedEvent(ChangeEvent<bool> evt) //(ClickEvent evt)  //
    {

        var targetBox = evt.target as Toggle;

        //Debug.Log(targetBox.name);


        if (targetBox.value)
        {
            targetBox.style.backgroundImage = Toggle_img[0];
            //안보여야함.
            targetBox.Q("unity-checkmark").style.visibility = Visibility.Hidden;

            if (targetBox.name.Equals("Loading_video"))
            {
                set_url = VideoUrl;
            }
            else
            {
                gameObject.GetComponent<UIDocument>().rootVisualElement.Q("LoadingSceneView").Q(targetBox.name).style.visibility = Visibility.Hidden;
            }

        }
        else
        {

            //배경바꾸기
            targetBox.style.backgroundImage = Toggle_img[1];
            //보여야함
            targetBox.Q("unity-checkmark").style.visibility = Visibility.Visible;
            if (targetBox.name.Equals("Loading_video"))
            {
                set_url = VideoUrl;
            }
            else
            {
                gameObject.GetComponent<UIDocument>().rootVisualElement.Q("LoadingSceneView").Q(targetBox.name).style.visibility = Visibility.Visible;
            }

        }

    }


    // 로딩씬의 변경 버튼 클릭 시 
    private void OnBtnClickedEvent(ClickEvent evt)
    {

        Label btnName = evt.target as Label;
        string[] words = btnName.name.Split('-');
        string assetname = ""; //words[1];
        Debug.Log(words[0]);
        var root = gameObject.GetComponent<UIDocument>().rootVisualElement;
        //gameObject.GetComponent<EditUITool>().createEdit(evt.target as VisualElement, 450, 300);
        switch (words[1])
        {
            case "Loading_logo":
                gameObject.GetComponent<EditUITool>().targetUiType = CMS_TYPES.CMSUIType.Cms_img;
                break;
            case "Loading_video":
                gameObject.GetComponent<EditUITool>().targetUiType = CMS_TYPES.CMSUIType.Cms_video;
                break;
            case "infotext":
                gameObject.GetComponent<EditUITool>().targetUiType = CMS_TYPES.CMSUIType.Cms_txt;
                break;
            default:
                Debug.Log("잘못된 접근 경로입니다.");
                break;
        }
        gameObject.GetComponent<EditUITool>().createEdit(root.Q<VisualElement>("cms_page"), 668, 900);

    }

}
