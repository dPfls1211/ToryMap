using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class setURL : MonoBehaviour
{
    public string loadingSceneURL;
    public string uijeongbuVideo1 = "Assets/Resources/Video/Uijeongbu.mp4";

    public VideoClip uijeongbuVideo;
    URLSave urls;

    private void Awake()
    {
        loadingSceneURL = System.IO.Path.Combine(Application.streamingAssetsPath, "Uijeongbu.mp4");
        //gameObject.GetComponent<VideoPlayer>().clip = uijeongbuVideo;
        gameObject.GetComponent<VideoPlayer>().url = loadingSceneURL;

        gameObject.GetComponent<VideoPlayer>().Play();
    }
    // public GameObject urlbtn;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     urls = urlbtn.GetComponentInChildren<URLSave>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(urls.changeURL){
    //         startchangeURL();
    //     }
    // }
    // void startchangeURL(){

    //     this.GetComponent<VideoPlayer>().Stop();
    //     this.GetComponent<VideoPlayer>().url = urls.saveURL;
    //     //Debug.Log(this.GetComponent<VideoPlayer>().url);
    //     this.GetComponent<VideoPlayer>().Play();
    //     urls.changeURL=false;
    // }
}
