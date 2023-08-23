using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class load_panelvideo : MonoBehaviour
{
    // Start is called before the first frame update
    string loadingSceneURL;
    string loadingSceneURL2;
    string loadingSceneURL3;

    public GameObject videoplayer1;
    public GameObject videoplayer2;
    public GameObject videoplayer3;
    public VideoClip video1;
    public VideoClip video2;
    public VideoClip video3;
    private void Awake()
    {
        loadingSceneURL2 = System.IO.Path.Combine(Application.streamingAssetsPath, "media-file.mp4");
        loadingSceneURL3 = System.IO.Path.Combine(Application.streamingAssetsPath, "Uijeongbu.mp4");
        loadingSceneURL = System.IO.Path.Combine(Application.streamingAssetsPath, "video1.mp4");


        videoplayer1.GetComponent<VideoPlayer>().url = loadingSceneURL;
        videoplayer2.GetComponent<VideoPlayer>().url = loadingSceneURL2;
        videoplayer3.GetComponent<VideoPlayer>().url = loadingSceneURL3;

        // videoplayer1.GetComponent<VideoPlayer>().clip = video1;
        //videoplayer2.GetComponent<VideoPlayer>().clip = video2;
        // videoplayer3.GetComponent<VideoPlayer>().clip = video3;

        videoplayer1.GetComponent<VideoPlayer>().Play();
        videoplayer2.GetComponent<VideoPlayer>().Play();
        videoplayer3.GetComponent<VideoPlayer>().Play();
    }


}
