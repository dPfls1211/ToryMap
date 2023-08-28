using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class open_videomodal : MonoBehaviour
{
    GameObject recodeplay;
    video_info videoinfo;
    start_videomodal newvideo;
    public static bool videomodalon = false;

    public TextMeshProUGUI description_box;
    public TextMeshProUGUI description_box_explation;
    // Start is called before the first frame update
    void Start()
    {
        videoinfo = GameObject.Find("GameObject").GetComponent<video_info>();
        recodeplay = GameObject.Find("recodeplay_modal1").transform.GetChild(0).transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onclick()
    {
        //영상 클릭하면 클릭한 영상 정보 저장
        videoinfo.click = GetComponent<VideoPlayer>().targetTexture;
        videoinfo.clickrender = GetComponent<RawImage>().texture;
        videoinfo.clickclip = GetComponent<VideoPlayer>().clip;

        // 비디오 play모달 on
        //Debug.Log(click.name);
        openModal.recodemodal.SetActive(false);
        recodeplay.SetActive(true);
        newvideo = GameObject.Find("RawImage").GetComponent<start_videomodal>();

        //newvideo.newcontentclick();

    }

    public void updatevideo()
    {
        if (videomodalon)
        {
            newvideo.newcontentclick();
        }
        videomodalon = true;
    }

}
