using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UIElements;

public class EditUITool : MonoBehaviour
{
    public CMS_TYPES.CMSUIType targetUiType;
    public string[] VideoPlayerList;
    public Sprite[] ImageList;
    public static Sprite EditImg;
    public static string EditText;
    public static string EditVideoUrl;
    public UIDocument EditUI;
    public VisualTreeAsset EditUIs;

    TemplateContainer beforeOBJ;
    VisualElement SetTargetObj;


    private VisualElement EditImgs;
    private TemplateContainer editorUI;
    private TextField EditTextField;
    private Button _closeBtn;
    private Button _SetBtn;

    //public VideoPlayer ddddd;
    // Start is called before the first frame update
    void Start()
    {
        // var root = EditUI.rootVisualElement;
        // createEdit(root, 450, 300);
        // Debug.Log(editorUI);
    }

    private void OnCloseBtnClicked(ClickEvent evt)  //취소하기
    {
        resetInfo();

    }

    private void resetInfo()
    {
        //저장해뒀던 OBJ를 클리어.
        Debug.Log("clear");
        //EditUI.enabled = false;
        EditImg = null;
        EditText = null;
        EditVideoUrl = null;

        //UI ToolKit element 삭제
        if (beforeOBJ != null)
            beforeOBJ.RemoveFromHierarchy();
    }

    //적용하기
    private void OnSetBtnClicked(ClickEvent evt)
    {
        Debug.Log(targetUiType);
        if (targetUiType == CMS_TYPES.CMSUIType.Cms_txt || targetUiType == CMS_TYPES.CMSUIType.Cms_video)
            GetComponent<UIInfoData>().setChangedUI(EditTextField.text);
        if (targetUiType == CMS_TYPES.CMSUIType.Cms_img)
            GetComponent<UIInfoData>().setChangedUI(EditImg);
        //비디오는 해당 이미지가 담고 있는 값을 갖고와야하니.. 나중에 생각해봅시다.

        resetInfo();
        //변수 저장해야함
        //table 내용이 바뀌어야함.
        /// 바뀐 변수를 바탕으로 화면과, 메인 씬이 바뀌어야함..
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
        EditImgs = ui.Q<VisualElement>("EditImgs");
        EditTextField = ui.Q<TextField>("SettingText");
        _closeBtn = ui.Q<Button>("closeBTN");
        _SetBtn = ui.Q<Button>("SetBTN");

        _closeBtn.RegisterCallback<ClickEvent>(OnCloseBtnClicked);
        _SetBtn.RegisterCallback<ClickEvent>(OnSetBtnClicked);

        //(이미지) 타입이, 이미지면 자식객체 찾아와서 이벤트 추가 해주기
        if (targetUiType == CMS_TYPES.CMSUIType.Cms_img)
        {
            for (int index = 0; index < EditImgs.childCount; index++)
            {
                EditImgs[index].RegisterCallback<ClickEvent>(selectingIMG);
                Debug.Log(EditImgs[index].name);
            }
        }


        ui.style.width = w;
        ui.style.height = h;
        ui.style.position = Position.Absolute;
        ui.style.bottom = 100;
        ui.style.right = 50;
    }
    //이미지 클릭함수
    public void selectingIMG(ClickEvent evt)
    {
        var img_UI = evt.target as VisualElement;
        int orderNumber = EditImgs.IndexOf(img_UI);
        EditImg = ImageList[orderNumber];
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



    // Update is called once per frame
    void Update()
    {

    }
}
