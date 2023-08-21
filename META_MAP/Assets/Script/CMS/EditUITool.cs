using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Video;
using UnityEngine.UIElements;

public class EditUITool : MonoBehaviour
{
    public CMS_TYPES.CMSUIType targetUiType;
    public string[] VideoPlayerList;
    public Sprite[] ImageList;
    public VideoClip[] VideoList;

    private List<RenderTexture> VideoRenderTex = new List<RenderTexture>();
    public static Sprite EditImg = null;
    public static string EditText = null;
    public static string EditVideoUrl;
    public static VideoClip EditVideo;
    public UIDocument EditUI;
    public VisualTreeAsset EditUIs;
    public VisualTreeAsset gallery_contentsbox;
    public FontAsset semibold;
    public FontAsset reguler;


    TemplateContainer beforeOBJ;
    VisualElement SetTargetObj;


    private VisualElement EditImgs;
    private TemplateContainer editorUI;
    private TextField EditTextField;
    private Button _closeBtn;
    private Button _SetBtn;
    private VisualElement Text_Editor;
    private VisualElement Img_Editor;



    string save_fieldText = "";

    //public VideoPlayer ddddd;
    // Start is called before the first frame update
    void Start()
    {
        // var root = EditUI.rootVisualElement;
        // createEdit(root, 450, 300);
        // Debug.Log(editorUI);
        int video_index = 0;
        RenderTexture[] AddArray = new RenderTexture[VideoList.Length];

        foreach (var _video_ in VideoList)
        {
            RenderTexture video_source_background = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
            video_source_background.Create();
            video_source_background.Release();
            GameObject Tex_videoPlayer = new GameObject();
            Tex_videoPlayer.AddComponent<VideoPlayer>().targetTexture = video_source_background;
            Tex_videoPlayer.GetComponent<VideoPlayer>().source = VideoSource.VideoClip;
            Tex_videoPlayer.GetComponent<VideoPlayer>().clip = _video_;



            VideoRenderTex.Add(video_source_background);
        }
    }
    private void Update()
    {
        //if문 Textfield켜졌을때만,



        if (EditTextField != null && EditTextField.style.display != DisplayStyle.None)
        {
            //Debug.Log(EditTextField.text.Length);

            //텍스트바꾸기
            if (EditTextField.text.Length > 220)
            {
                EditTextField.value = save_fieldText[0..^0];
            }
            else
            {
                Text_Editor.Q<Label>("current-text-count").text = EditTextField.text.Length.ToString();
                save_fieldText = EditTextField.text;
            }
        }
    }

    private void OnCloseBtnClicked(ClickEvent evt)  //취소하기
    {
        resetInfo();


    }

    private void resetInfo()
    {
        //저장해뒀던 OBJ를 클리어.
        //Debug.Log("clear");
        //EditUI.enabled = false;
        EditImg = null;
        EditVideoUrl = null;

        //UI ToolKit element 삭제
        if (beforeOBJ != null)
            beforeOBJ.RemoveFromHierarchy();
    }

    //적용하기
    private void OnSetBtnClicked(ClickEvent evt)
    {
//        Debug.Log(targetUiType);
        try
        {
            if (targetUiType == CMS_TYPES.CMSUIType.Cms_txt)
            {
                EditText = EditTextField.text;
                GetComponent<UIInfoData>().setChangedUI(EditTextField.text);
            }
            if (targetUiType == CMS_TYPES.CMSUIType.Cms_img)
                GetComponent<UIInfoData>().setChangedUI(EditImg);
            if (targetUiType == CMS_TYPES.CMSUIType.Cms_video)
                GetComponent<UIInfoData>().setChangedUI(EditVideo);

        }
        catch (NullReferenceException ex)
        {
            //resetInfo();
        }


        //비디오는 해당 이미지가 담고 있는 값을 갖고와야하니.. 나중에 생각해봅시다.

        resetInfo();
        //변수 저장해야함
        //table 내용이 바뀌어야함.
        /// 바뀐 변수를 바탕으로 화면과, 메인 씬이 바뀌어야함..
    }

    public void selectingVideo(ClickEvent evt)
    {
        var img_UI = evt.target as VisualElement;
        int orderNumber = EditImgs.IndexOf(img_UI.parent);

//        Debug.Log(orderNumber);
        //EditImg = new Sprite(img_UI.style.backgroundImage);
        EditVideo = VideoList[orderNumber];
    }

    //이미지 클릭함수
    public void selectingIMG(ClickEvent evt)
    {
        var img_UI = evt.target as VisualElement;
        int orderNumber = EditImgs.IndexOf(img_UI.parent);

        Debug.Log(orderNumber);
        //EditImg = new Sprite(img_UI.style.backgroundImage);
        EditImg = ImageList[orderNumber];
    }

    //input field 클릭 시 글씨체, 글씨 색 변하는 함수
    private void OnchangeSetInputfield(ClickEvent evt)
    {
        TextField element = evt.target as TextField;
        changeColorText(element, new Color(18 / 255, 18 / 255, 18 / 255), semibold);
        // Color changedColor = new Color(18 / 255, 18 / 255, 18 / 255);
        // element.style.color = new StyleColor(changedColor);
        // element.style.unityFontDefinition = FontDefinition.FromSDFFont(semibold);

    }
    private void changeColorText(TextField element, Color changeColor, FontAsset font)
    {

        element.style.color = new StyleColor(changeColor);
        element.style.unityFontDefinition = FontDefinition.FromSDFFont(font);
    }

    private void OnTextAllDelete(ClickEvent evt)
    {  //314D79

        Label element = evt.target as Label;

        EditTextField.value = "의정부 리버사이드 메타맵에 오신 것을 환영합니다.  의정부를 꼭 담은 가상 스테이지에서 다양한 지역 서비스를 즐기시길 바랍니다.";
        changeColorText(EditTextField, new Color(0.8039216f, 0.8039216f, 0.8039216f), reguler);
        // Color changedColor = new Color(0.8039216f, 0.8039216f, 0.8039216f);
        // EditTextField.style.color = new StyleColor(changedColor);
        // EditTextField.style.unityFontDefinition = FontDefinition.FromSDFFont(reguler);
    }

    //편집창 생성
    public void createEdit(VisualElement parentElement, float width, float height)
    {
        resetInfo();

        //현재꺼 obj를 저장.? 아직 작성안한 코드.

        //생성
        editorUI = EditUIs.Instantiate();
        beforeOBJ = editorUI;
        SetTargetObj = parentElement;
        parentElement.Add(editorUI);
        setting_start(editorUI, width, height);
    }

    //편집창 내부 셋팅
    public void setting_start(TemplateContainer ui, float w, float h)
    {
//        Debug.Log(EditText);
        EditImgs = ui.Q<ScrollView>("contents-gallery");
        EditTextField = ui.Q<TextField>("edit-text-input");
        _closeBtn = ui.Q<Button>("closeBTN");
        _SetBtn = ui.Q<Button>("SetBTN");

        _closeBtn.RegisterCallback<ClickEvent>(OnCloseBtnClicked);
        _SetBtn.RegisterCallback<ClickEvent>(OnSetBtnClicked);


        Text_Editor = ui.Q<VisualElement>("text-editor");
        Img_Editor = ui.Q<VisualElement>("img-editor");
        Label Edit_name = ui.Q<Label>("popup-header-title");

        if (targetUiType == CMS_TYPES.CMSUIType.Cms_txt)
        {
            Text_Editor.style.display = DisplayStyle.Flex;
            Img_Editor.style.display = DisplayStyle.None;
            if (EditText != null)
            {
                EditTextField.value = EditText;
                changeColorText(EditTextField, new Color(18 / 255, 18 / 255, 18 / 255), semibold);
            }
            EditTextField.RegisterCallback<ClickEvent>(OnchangeSetInputfield);
            Label text_delete = ui.Q<Label>("edit-text-allDelete");
            text_delete.RegisterCallback<ClickEvent>(OnTextAllDelete);
            Edit_name.text = "소개 문구 편집";
        }
        if (targetUiType == CMS_TYPES.CMSUIType.Cms_img || targetUiType == CMS_TYPES.CMSUIType.Cms_video)
        {
            Text_Editor.style.display = DisplayStyle.None;
            Img_Editor.style.display = DisplayStyle.Flex;

            if (targetUiType == CMS_TYPES.CMSUIType.Cms_img)
            {
                Edit_name.text = "이미지 편집";


                foreach (var index_ in ImageList)
                {
                    //ui 추가하고, 

                    EditImgs.Add(gallery_contentsbox.Instantiate());

                    VisualElement img_visualelement = EditImgs.Q<VisualElement>("gallery-content");
                    //이미지 셋. gallery-content
                    img_visualelement.style.backgroundImage = new StyleBackground(index_);
                    //클릭이벤트 추가
                    img_visualelement.RegisterCallback<ClickEvent>(selectingIMG);
                    img_visualelement.name = "gallery-content-" + index_.name;
                    //EditImgs[index].RegisterCallback<ClickEvent>(selectingIMG);

                }




                //(이미지) 타입이, 이미지면 자식객체 찾아와서 이벤트 추가 해주기
                // for (int index = 0; index < EditImgs.childCount; index++)
                // {
                //     EditImgs[index].RegisterCallback<ClickEvent>(selectingIMG);

                // }

            }
            if (targetUiType == CMS_TYPES.CMSUIType.Cms_video)
            {
                Edit_name.text = "영상 편집";
                int index_v_count = 0;
                foreach (var index_v in VideoRenderTex)
                {
                    //ui 추가하고, 

                    EditImgs.Add(gallery_contentsbox.Instantiate());

                    VisualElement img_visualelement = EditImgs.Q<VisualElement>("gallery-content");
                    //이미지 셋. gallery-content
                    img_visualelement.style.backgroundImage = new StyleBackground(Background.FromRenderTexture(index_v));
                    //클릭이벤트 추가
                    img_visualelement.RegisterCallback<ClickEvent>(selectingVideo);
                    img_visualelement.name = "gallery-content-" + index_v_count++;
                    //EditImgs[index].RegisterCallback<ClickEvent>(selectingIMG);

                }
            }
        }






        ui.style.width = w;
        ui.style.height = h;
        ui.style.position = Position.Absolute;
        ui.style.bottom = 100;
        ui.style.right = 50;
    }


    public Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }

    public string setTextToChangeWord()
    {
        return EditText;
    }
    public Sprite setImgToChangeImg()
    {
        return EditImg;
    }
    public string setVideoToChangeUrl()
    {
        return EditVideoUrl;
    }


}
