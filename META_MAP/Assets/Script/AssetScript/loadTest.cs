using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class loadTest : MonoBehaviour
{


    string BasicUrl = "http://192.168.0.55:81/objAssetTest/WinVer/";

    string AssetBundleName_ = "uijeongbumap3d";
    string SaveAssetBundleName_ = "uijeongbumap3d";
    string AssetBundleObjName_ = "plane_map";


    string assetBundleDirectory = "Assets/AssetBundleObj";
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL
        //BasicUrl = "http://192.168.0.55:81/dw/testAsse tBundle/webVer/";
        BasicUrl = "http://192.168.0.55:81/objAssetTest/WebVer/";
        assetBundleDirectory = "Assets/AssetBundleObj";
#elif UNITY_EDITOR
        assetBundleDirectory = "Assets/AssetBundleObj";
#else
        //BasicUrl = "http://192.168.0.55:81/dw/testAssetBundle/winVer1/";
        BasicUrl = "http://192.168.0.55:81/MapobjAssetTestTest/WinVer/";
        assetBundleDirectory = Application.persistentDataPath;
#endif

        StartSave();
    }

    public void StartSave()
    {
        //StartCoroutine(SaveAssetBundleOnDisk("icon-resources-view", "icon-resources-view"));

        StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName_, SaveAssetBundleName_));
        // StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName_, "SaveAssetBundleName_"));
    }

    public void Load()
    {
        //StartCoroutine(LoadAssetFromLocalDisk("icon-resources-view", "icon-resources-view", false));
        StartCoroutine(LoadAssetFromLocalDisk(SaveAssetBundleName_, AssetBundleObjName_, true));

        //StartCoroutine(LoadImageAssetFromLocalDisk("icon-resources-view", "restaurant"));
        // StartCoroutine(LoadImageAssetFromLocalDisk(SaveAssetBundleName_, AssetBundleObjName_, (prefab_) =>
        // {
        //     viewimage.GetComponent<Image>().sprite = prefab_;
        // }));
        //var rrr = ImageLoad(AssetBundleName_, SaveAssetBundleName_, AssetBundleObjName_);
    }


    public IEnumerator SaveAssetBundleOnDisk(string AssetBundleName, string DiskOnAssetBundleName)
    {

        // 에셋 번들을 받아오고자하는 서버의 주소

        // 지금은 주소와 에셋 번들 이름을 함께 묶어 두었지만

        // 주소 + 에셋 번들 이름 형태를 띄는 것이 좋다.
        string uri = BasicUrl + AssetBundleName;
        //Debug.Log(uri);


        // 웹 서버에 요청을 생성한다.
        UnityWebRequest request = UnityWebRequest.Get(uri);
        request.Send();


        while (!request.isDone)
        {

            Debug.Log("isdone " + request.isDone);
            Debug.Log("progress " + request.downloadProgress);
            AssetbundleLoading.AssetBundleLoadingProgress = request.downloadProgress;
            yield return null;
        }




        // 에셋 번들을 저장할 경로

        //string assetBundleDirectory = "Assets/AssetBundleObj";
        // 에셋 번들을 저장할 경로의 폴더가 존재하지 않는다면 생성시킨다.
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }



        // 파일 입출력을 통해 받아온 에셋을 저장하는 과정
        FileStream fs = new FileStream(assetBundleDirectory + "/" + DiskOnAssetBundleName, System.IO.FileMode.Create);
        fs.Write(request.downloadHandler.data, 0, (int)request.downloadedBytes);
        fs.Close();
        Debug.Log("Completly");


    }
    IEnumerator LoadAssetFromLocalDisk(string DiskOnAssetBundleName, string AssetBundleObjName, bool check_Dep)
    {
        Debug.Log("loadStart");
        //string assetBundleDirectory = "Assets/AssetBundleObj";
        // 저장한 에셋 번들로부터 에셋 불러오기
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));

        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }
        else
            Debug.Log("Successed to load AssetBundle!");
        if (check_Dep)
        {
            var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(AssetBundleObjName);

            Instantiate(prefab, Vector3.zero, Quaternion.identity);

        }
        myLoadedAssetBundle.Unload(false);
    }
    //uijeongbumap3d
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Load();
        }
    }
}
