using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AssetLoaders_dont : MonoBehaviour
{
    public static AssetLoaders_dont instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    //public string BasicUrl = "http://192.168.0.55:81/dw/testAssetBundle/";
    public string BasicUrl = "http://192.168.0.55:81/Map/Mapfile/MapImage";

    public string AssetBundleName_ = "dinosaurs";
    public string SaveAssetBundleName_ = "dinosaurs";
    public string AssetBundleObjName_ = "tiranosaurus";

    public Image viewimage;

    private void Start()
    {
#if UNITY_WEBGL
        BasicUrl = "http://192.168.0.55:81/dw/testAssetBundle/webVer/";
#else
        BasicUrl = "http://192.168.0.55:81/dw/testAssetBundle/winVer/";
#endif
        /////////이미지 테스트 예정
        BasicUrl = "http://192.168.0.55:81/Map/Mapfile/MapImage";
        StartSave();

    }

    public void StartSave()
    {
        StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName_, SaveAssetBundleName_));
    }
    public void Load()
    {
        StartCoroutine(LoadAssetFromLocalDisk(SaveAssetBundleName_, AssetBundleObjName_));

    }

    public Image ImageLoad(string AssetBundleName, string DiskOnAssetBundleName, string AssetBundleObjName)
    {
        StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName, DiskOnAssetBundleName));
        //StartCoroutine(LoadImageAssetFromLocalDisk(DiskOnAssetBundleName, AssetBundleObjName));
        StartCoroutine(LoadImageAssetFromLocalDisk(DiskOnAssetBundleName, AssetBundleObjName, (prefab_) =>
        {
            viewimage = prefab_;
        }));
        return viewimage;
    }
    // 서버에서 받아오고자 하는 에셋 번들의 이름 목록

    // 지금은 간단한 배열 형태를 사용하고 있지만 이후에는

    // xml이나 json을 사용하여 현재 가지고 있는 에셋 번들의 버전을 함께 넣어주고

    // 서버의 에셋 번들 버전 정보를 비교해서 받아오는 것이 좋다.
    public string[] assetBundleNames;

    IEnumerator SaveAssetBundleOnDisk(string AssetBundleName, string DiskOnAssetBundleName)
    {

        // 에셋 번들을 받아오고자하는 서버의 주소

        // 지금은 주소와 에셋 번들 이름을 함께 묶어 두었지만

        // 주소 + 에셋 번들 이름 형태를 띄는 것이 좋다.
        string uri = BasicUrl + AssetBundleName;
        Debug.Log(BasicUrl);


        // 웹 서버에 요청을 생성한다.
        UnityWebRequest request = UnityWebRequest.Get(uri);

        //UnityWebRequest request = UnityWebRequest.GetAssetBUndle(uri,0);
        yield return request.Send();

        //AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        //LoadAsset<GameObject>("이름");


        // 에셋 번들을 저장할 경로
        string assetBundleDirectory = "Assets/AssetBundleObj";
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

    IEnumerator LoadAssetFromLocalDisk(string DiskOnAssetBundleName, string AssetBundleObjName) //call형식으로 instantiate된 객체 넘겨주기 가능?
    {
        string assetBundleDirectory = "Assets/AssetBundleObj";
        // 저장한 에셋 번들로부터 에셋 불러오기
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }
        else
            Debug.Log("Successed to load AssetBundle!");

        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>(AssetBundleObjName);
        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    // IEnumerator LoadImageAssetFromLocalDisk(string DiskOnAssetBundleName, string AssetBundleObjName)
    // {
    //     string assetBundleDirectory = "Assets/AssetBundleObj";
    //     Debug.Log(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
    //     // 저장한 에셋 번들로부터 에셋 불러오기
    //     var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
    //     if (myLoadedAssetBundle == null)
    //     {
    //         Debug.Log("Failed to load AssetBundle!");
    //         yield break;
    //     }
    //     else
    //         Debug.Log("Successed to load AssetBundle!");

    //     var prefab = myLoadedAssetBundle.LoadAsset<Image>(AssetBundleObjName);
    //     //Instantiate(prefab, Vector3.zero, Quaternion.identity); 
    // }
    IEnumerator LoadImageAssetFromLocalDisk(string DiskOnAssetBundleName, string AssetBundleObjName, System.Action<Image> callback)
    {
        string assetBundleDirectory = "Assets/AssetBundleObj";
        // 저장한 에셋 번들로부터 에셋 불러오기
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }
        else
            Debug.Log("Successed to load AssetBundle!");

        var prefab = myLoadedAssetBundle.LoadAsset<Image>(AssetBundleObjName);
        Debug.Log(prefab);
        if (prefab != null)
            callback(prefab);
        //Instantiate(prefab, Vector3.zero, Quaternion.identity); 
    }
}