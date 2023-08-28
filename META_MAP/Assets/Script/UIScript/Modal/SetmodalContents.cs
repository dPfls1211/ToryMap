using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using TMPro;

public class SetmodalContents : MonoBehaviour
{
    public string modalTitle = "교육/회의 관련 정보";
    public GameObject contentsPrefab;
    public static int contentsCount = 8;
    public GameObject contentsBox;

    public bool darkmode = false;

    GameObject[] contentlist;
    public List<GameObject> Tex_videoPlayerlist;
    public VideoClip[] _video_;
    private List<RenderTexture> VideoRenderTex = new List<RenderTexture>();

    GameObject Tex_videoPlayer;
    open_videomodal checkbool;
    // Start is called before the first frame update
    void Awake()  //나중에 JSON정보 읽어와서 foreach해서 생성되도록.
    {
        _video_ = GameObject.Find("GameObject").GetComponent<video_info>().video;
        contentlist = new GameObject[contentsCount];
        Tex_videoPlayer = new GameObject();
        Tex_videoPlayer.name = "makenew";
        for (int i = 0; i < contentsCount; i++)
        {
            contentlist[i] = Instantiate(contentsPrefab);
            contentlist[i].transform.SetParent(contentsBox.transform);
        }
        if (darkmode)
        {

        }
    }
    private void Update()
    {
        if (open_videomodal.videomodalon)
        {
            insertvideo();
        }

    }
    public void wait()
    {

        //StartCoroutine("waitonetime2");

        foreach (var i in Tex_videoPlayerlist)
        {
            StartCoroutine(waitonetime(i));
        }
    }



    public void makerender()
    {
        for (int i = 0; i < contentsCount; i++)
        {
            RenderTexture video_source_background = new RenderTexture(1920, 1080, 16, RenderTextureFormat.ARGB32);
            video_source_background.Create();
            video_source_background.Release();
            Tex_videoPlayer = new GameObject();
            video_source_background.name = "rendertexture";
            Tex_videoPlayer.AddComponent<VideoPlayer>().targetTexture = video_source_background;
            Tex_videoPlayer.GetComponent<VideoPlayer>().source = VideoSource.VideoClip;
            Tex_videoPlayer.GetComponent<VideoPlayer>().clip = _video_[i];
            Tex_videoPlayerlist.Add(Tex_videoPlayer);
            contentlist[i].GetComponent<VideoPlayer>().clip = _video_[i];
            contentlist[i].GetComponent<VideoPlayer>().targetTexture = video_source_background;

            VideoRenderTex.Add(video_source_background);
            contentlist[i].GetComponent<RawImage>().texture = VideoRenderTex[i];
            Tex_videoPlayer.GetComponent<VideoPlayer>().Play();
        }
        description();
        wait();

    }




    IEnumerator waitonetime(GameObject list)
    {
        list.GetComponent<VideoPlayer>().Stop();
        list.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(0.25f);
        list.GetComponent<VideoPlayer>().Pause();
    }
    public void insertvideo()
    {
        SetmodalContents contetn = openModal.recodemodal.GetComponent<SetmodalContents>();
        for (int i = 0; i < contentsCount; i++)
        {
            contentlist[i].GetComponent<VideoPlayer>().clip = contetn._video_[i];
            contentlist[i].GetComponent<VideoPlayer>().targetTexture = contetn.Tex_videoPlayerlist[i].GetComponent<VideoPlayer>().targetTexture;
            contentlist[i].GetComponent<RawImage>().texture = contetn.contentlist[i].GetComponent<RawImage>().texture;
        }
        description();
    }
    public void description()
    {
        for (int i = 0; i < contentsCount; i++)
        {
            contentlist[i].GetComponentInChildren<TextMeshProUGUI>().text = _video_[i].name;
            contentlist[i].transform.GetChild(1).transform.gameObject.GetComponent<TextMeshProUGUI>().text = _video_[i].name;
        }
    }
    public void removeall()
    {
        foreach (var li in Tex_videoPlayerlist)
        {
            Destroy(li);
        }
        Tex_videoPlayerlist.Clear();
        GameObject make = GameObject.Find("makenew");
        if (make != null)
        {
            Destroy(make);
        }

    }

}
