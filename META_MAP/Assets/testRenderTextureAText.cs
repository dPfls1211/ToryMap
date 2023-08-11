using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UIElements;

public class testRenderTextureAText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()  //비디오 테스트
    {
        RenderTexture re = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
        re.Create();
        re.Release();
        Debug.Log(re);
        gameObject.GetComponent<VideoPlayer>().targetTexture = re;

        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<VisualElement>("testvideoplayer").style.backgroundImage = new StyleBackground(Background.FromRenderTexture(re));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
