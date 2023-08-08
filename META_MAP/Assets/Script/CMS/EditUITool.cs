using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EditUITool : MonoBehaviour
{
    public static Texture2D EditImg;
    public static string EditText;
    public static string EditVideoUrl;
    public UIDocument EditUI;
    public VisualTreeAsset EditUIs;


    private VisualElement EditImgs;
    private TemplateContainer editorUI;
    private TextField EditTextField;
    private Button _closeBtn;
    private Button _SetBtn;
    // Start is called before the first frame update
    void Start()
    {
        // var root = EditUI.rootVisualElement;
        // createEdit(root, 450, 300);
        // Debug.Log(editorUI);
    }

    private void OnCloseBtnClicked(ClickEvent evt)
    {
        EditUI.enabled = false;
        EditImg = null;
        EditText = null;
        EditVideoUrl = null;
    }

    private void OnSetBtnClicked(ClickEvent evt)
    {

    }
    public void createEdit(VisualElement parentElement, float width, float height)
    {
        editorUI = EditUIs.Instantiate();
        parentElement.Add(editorUI);
        setting_start(editorUI, width, height);
    }

    public void setting_start(TemplateContainer ui, float w, float h)
    {
        EditImgs = ui.Q<VisualElement>("EditImgs");
        EditTextField = ui.Q<TextField>("SettingText");
        _closeBtn = ui.Q<Button>("closeBTN");
        _SetBtn = ui.Q<Button>("SetBTN");

        _closeBtn.RegisterCallback<ClickEvent>(OnCloseBtnClicked);
        _SetBtn.RegisterCallback<ClickEvent>(OnSetBtnClicked);

        ui.style.width = w;
        ui.style.height = h;
        ui.style.position = Position.Absolute;
        ui.style.bottom = 0;
        ui.style.right = 50;
    }

    public string setTextToChangeWord()
    {
        return EditText;
    }
    public Texture2D setImgToChangeImg()
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
