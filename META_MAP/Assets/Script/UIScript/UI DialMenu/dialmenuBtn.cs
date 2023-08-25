using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class dialmenuBtn : MonoBehaviour, IPointerClickHandler
{
    public string nextSceneName;
    public string stageName;
    public Texture iconImage;

    public TMP_Text stageText;
    public RawImage stageIcon;


    // Start is called before the first frame update
    void Start()
    {
        stageIcon.texture = iconImage;

        stageIcon.SetNativeSize();
        stageText.text = stageName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LoadingSceneManager.LoadScene(nextSceneName);

    }
}
