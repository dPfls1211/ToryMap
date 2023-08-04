using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SideBarBtn : MonoBehaviour
{
    public Texture SceneImage;
    public string OnClickUrl;
    public Texture iconImage;
    public string text_name;

    public TMP_Text BtnNameText;
    public RawImage BtnIcon;

    public string mainSceneName = "0707test";
    public string ClickedSceneName = "0718TestScene";

    // Start is called before the first frame update
    void Start()
    {
        BtnNameText.text = text_name;
        if (iconImage == null)
        {
            if (BtnIcon != null)
                BtnIcon.enabled = false;
            BtnNameText.color = new Color32(212, 212, 212, 255);
            BtnNameText.fontStyle = FontStyles.Normal;
        }
        else
        {
            BtnIcon.texture = iconImage;
            BtnIcon.SetNativeSize();
            BtnIcon.rectTransform.localScale = new Vector3(0.05f, 0.05f, 0.05f);



        }
    }


    public void onClickToURL()
    {
        //Application.OpenURL(OnClickUrl);  //씬이동으로 변경, 배경 바꿔주기
        if (SceneImage == null)
        {
            //SceneManager.LoadScene("0707test");.
            //SceneLoader.Instance.LoadScene("TestViewScene");
            //  LoadingSceneManager.LoadScene(mainSceneName);

        }
        else
        {
            DontDestioryObj.instance.image_mainBackground = SceneImage;

            // SceneManager.LoadScene("testLoadVirtualSeoul");
            //SceneLoader.Instance.LoadScene("testLoadVirtualSeoul");


        }


        LoadingSceneManager.LoadScene(ClickedSceneName);
        //SceneManager.LoadScene(ClickedSceneName);


    }
}
