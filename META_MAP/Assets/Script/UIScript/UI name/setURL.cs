using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class setURL : MonoBehaviour
{
    public static string loadingSceneURL = "http://192.168.0.55:81/video/video3.mp4";
    //public static string loadingSceneURL = "/video/video3.mp4";
    URLSave urls;

    private void Awake()
    {
        gameObject.GetComponent<VideoPlayer>().url = loadingSceneURL;
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
