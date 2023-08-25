using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class start_videomodal : MonoBehaviour
{
    video_info videomodal;
    RenderTexture video_source_background_1;
    GameObject Tex_videoPlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        videomodal = GameObject.Find("GameObject").GetComponent<video_info>();
        StartCoroutine("videoplay");
    }
    void OnEnable()
    {
        //videomodal켜지면 영상 넣고 시작
        // this.GetComponent<RawImage>().texture = videomodal.clickrender;
        // this.GetComponent<VideoPlayer>().targetTexture = videomodal.click;
        // this.GetComponent<VideoPlayer>().clip = videomodal.clickclip;
        // open_videomodal.videomodalon = true; GetComponent<VideoPlayer>().Play();
        makerender();
        //StartCoroutine("videoplay");

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator videoplay()
    {
        makerender();
        yield return new WaitForSeconds(1);
    }

    public void videostop()
    {
        this.GetComponent<VideoPlayer>().Stop();
    }
    public void makerender()
    {
        video_source_background_1 = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
        video_source_background_1.name = "rendertexture1";
        video_source_background_1.Create();
        video_source_background_1.Release();
        //Tex_videoPlayer = new GameObject();
        this.GetComponent<VideoPlayer>().targetTexture = video_source_background_1;
        this.GetComponent<VideoPlayer>().source = VideoSource.VideoClip;
        this.GetComponent<VideoPlayer>().clip = videomodal.clickclip;

        this.GetComponent<RawImage>().texture = video_source_background_1;
        GetComponent<VideoPlayer>().Play();
    }

    public void newcontentclick()
    {
        if (open_videomodal.videomodalon)
        {
            Debug.Log("!!");
            makerender();
        }
    }

}
