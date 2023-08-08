using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UIElements;

public class loadingToolkit : MonoBehaviour
{

    enum LoadingType
    {
        logo,
        wording,
        video
    }
    /// origin setting 
    private StyleBackground logoImg;
    private string VideoUrl;
    private string Text;

    public VisualTreeAsset rowContents_loading;

    private string[] loadingNames = { "Loading_logo", "Loading_video", "infotext" };
    private string[] contents = { "상단 로고", "의정부 리버사이드.png", "로딩 영상", "의정부 리버사이드.mp4", "소개 문구", "의정부 리버사이드에 오신 것을 환영합니다. 저희가 제공하는 가상 스테이지에서 지역 서비스를 경험하며, 즐거운 시간 보내시길 바랍니다." };
    public Texture2D[] Toggle_img = new Texture2D[2];

    //private VisualElement
    private StyleBackground set_img;
    private string set_text;
    private string set_url;

    private VisualElement Loading_logo;
    private Label Loading_infotxt;
    private VideoPlayer Loading_videoUrl;
    int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var i in loadingNames)
        {
            Debug.Log(12);
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



        contents_.Q<Toggle>("check_toggle").RegisterValueChangedCallback(OnCheckedEvent);
        contents_.Q<Toggle>("check_toggle").name = name;
        contents_.Q("changeBoxImg").RegisterCallback<ClickEvent>(OnBtnClickedEvent);
        contents_.Q("changeBoxImg").name = "changeBoxImg_" + name.ToString();

    }


    //체크버튼 클릭시
    private void OnCheckedEvent(ChangeEvent<bool> evt) //(ClickEvent evt)  //
    {
        var targetBox = evt.target as Toggle;

        //객체 판단
        //타입 설정
        int typeindex = 5;



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

        // //targetBox.SetEnabled(!targetBox.value);
        // targetBox.value = !targetBox.value;

    }
    // 변경 버튼 클릭 시 

    private void OnBtnClickedEvent(ClickEvent evt)
    {
        gameObject.GetComponent<EditUITool>().createEdit(evt.target as VisualElement, 450, 300);
    }
}
