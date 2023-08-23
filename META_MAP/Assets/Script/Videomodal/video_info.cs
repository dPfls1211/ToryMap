using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video_info : MonoBehaviour
{
    public Texture clickrender;
    public RenderTexture click;
    public VideoClip clickclip;

    public video_info videoinfo;
    public VideoClip[] video;
    public int videocount;

    public string loadingSceneURL;

    private void Awake()
    {
        clickclip = video[0];
    }
    void setvideo()
    {

        //loadingSceneURL = System.IO.Path.Combine(Application.streamingAssetsPath, "Uijeongbu.mp4");
    }


}
