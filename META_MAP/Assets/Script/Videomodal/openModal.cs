using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.UI;

public class openModal : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject recodemodal;
    public static GameObject recodevideomodal;
    public bool one = true;

    video_info videomodal;
    RenderTexture video_source_background_1;
    GameObject Tex_videoPlayer;
    GameObject newvideo;
    private void Awake()
    {
        videomodal = GameObject.Find("GameObject").GetComponent<video_info>();
        recodemodal = GameObject.Find("recode_modal").transform.GetChild(0).transform.gameObject;
        recodevideomodal = GameObject.Find("recodeplay_modal1").transform.GetChild(0).transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                //recodemodal.SetActive(true);
                recodevideomodal.SetActive(true);
                if (one)
                {
                    //첫번째 설정 모달사용할시
                    //recodemodal.GetComponent<SetmodalContents>().makerender();
                    //recodevideomodal.GetComponent<SetmodalContents>().makerender();
                }

                one = false;
            }
        }
    }
    public void closemodal()
    {
        recodemodal.SetActive(false);

    }
    public void makerender()
    {
        video_source_background_1 = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
        video_source_background_1.name = "rendertexture1";
        video_source_background_1.Create();
        video_source_background_1.Release();
        newvideo = GameObject.Find("RawImage");
        Tex_videoPlayer = new GameObject();
        newvideo.GetComponent<VideoPlayer>().targetTexture = video_source_background_1;
        newvideo.GetComponent<VideoPlayer>().source = VideoSource.VideoClip;
        newvideo.GetComponent<VideoPlayer>().clip = videomodal.clickclip;

        newvideo.GetComponent<RawImage>().texture = video_source_background_1;
        newvideo.GetComponent<VideoPlayer>().Play();

    }
}
