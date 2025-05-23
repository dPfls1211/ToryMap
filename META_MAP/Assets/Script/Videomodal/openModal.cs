using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class openModal : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject recodemodal;
    public static GameObject recodevideomodal;
    public static GameObject postermodal;
    public GameObject posterimg;
    public bool one = true;

    video_info videomodal;
    RenderTexture video_source_background_1;
    GameObject Tex_videoPlayer;
    GameObject newvideo;

    public static GameObject clickobj;
    GameObject kioskclosebtn;
    Camera maincam;
    GameObject DialMenu;
    private void Awake()
    {
        maincam = Camera.main;
        videomodal = GameObject.Find("GameObject").GetComponent<video_info>();
        recodemodal = GameObject.Find("recode_modal").transform.GetChild(0).transform.gameObject;
        recodevideomodal = GameObject.Find("recodeplay_modal1").transform.GetChild(0).transform.gameObject;
        postermodal = GameObject.Find("poster_modal").transform.GetChild(0).transform.gameObject;
        kioskclosebtn = GameObject.Find("kioskbtnCanvas").transform.GetChild(0).transform.gameObject;
        DialMenu = GameObject.Find("DialMenu");
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
                if (click_obj.name == "Cylinder.001")
                {
                    //첫번째 설정 모달사용할시
                    recodemodal.SetActive(true);
                    recodemodal.GetComponent<SetmodalContents>().makerender();
                    // recodevideomodal.SetActive(true);
                    //recodevideomodal.GetComponent<SetmodalContents>().makerender();
                }
                else if (click_obj.name == "poster1" || click_obj.name == "poster2")
                {
                    postermodal.SetActive(true);
                    getposter(click_obj);
                }
                else if (click_obj.name == "Kiosk")
                {
                    DialMenu.GetComponent<dialmenuAni>().showDialmenu = false;
                    cam360.iszoom = true;
                    GameObject parent = click_obj.transform.parent.gameObject;
                    parent.transform.GetChild(1).gameObject.SetActive(true);
                    kioskclosebtn.SetActive(true);
                    click_obj.SetActive(false);
                }
                clickobj = click_obj;
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
    void getposter(GameObject gam)
    {
        Texture tex = gam.GetComponent<RawImage>().texture;
        posterimg.GetComponent<RawImage>().texture = tex;
    }


}
