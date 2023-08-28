using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class dialmenuBtn : MonoBehaviour, IPointerClickHandler
{
    public bool nextScene = true;
    public float rotateAngle = 0;
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
        if (nextScene)
        {
            StartCoroutine(DelayNextScene());
            dialActiveAni.rotationAngle = rotateAngle;
        }
        else
        {
            //모달 띄우기
        }

    }

    IEnumerator DelayNextScene()
    {
        // Debug.Log(0);
        yield return new WaitForSeconds(0.4f);
        //fadeinout
        LoadingSceneManager.LoadScene(nextSceneName);
    }
}
