using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AssetLoader : MonoBehaviour
{
    public static AssetLoader instance = null;
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
    //string BasicUrl = "http://192.168.0.55:81/dw/testAssetBundle/";
    string BasicUrl = "http://192.168.0.55:81/MapTest/WinVer/";

    string AssetBundleName_ = "mapfileimage";
    string SaveAssetBundleName_ = "mapfileimage";
    string AssetBundleObjName_ = "guro";

    public RawImage viewimage;

    string assetBundleDirectory = "Assets/AssetBundleObj";


    private void Start()
    {
#if UNITY_WEBGL
        //BasicUrl = "http://192.168.0.55:81/dw/testAsse tBundle/webVer/";
        BasicUrl = "http://192.168.0.55:81/MapTest/WebVer/";
        assetBundleDirectory = "Assets/AssetBundleObj";
#elif UNITY_EDITOR
        assetBundleDirectory = "Assets/AssetBundleObj";
#else
        //BasicUrl = "http://192.168.0.55:81/dw/testAssetBundle/winVer1/";
        BasicUrl = "http://192.168.0.55:81/MapTest/WinVer/";
        assetBundleDirectory = Application.persistentDataPath;
#endif

        //StartSave();
        //GetAssetBundleInfo();
    }

    public void StartSave()
    {
        //StartCoroutine(SaveAssetBundleOnDisk("icon-resources-view", "icon-resources-view"));

        StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName_, SaveAssetBundleName_));
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

    public RawImage ImageLoad(string AssetBundleName, string DiskOnAssetBundleName, string AssetBundleObjName)
    {

        StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName, DiskOnAssetBundleName));
        //StartCoroutine(LoadImageAssetFromLocalDisk(DiskOnAssetBundleName, AssetBundleObjName));
        StartCoroutine(LoadImageAssetFromLocalDiskCall(DiskOnAssetBundleName, AssetBundleObjName, (prefab_) =>
        {
            viewimage.GetComponent<RawImage>().texture = prefab_;
        }));
        return viewimage;
    }

    public GameObject ObjLoad(string AssetBundleName, string DiskOnAssetBundleName, string AssetBundleObjName)
    {

        GameObject obj = new GameObject();
        StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName, DiskOnAssetBundleName));
        StartCoroutine(LoadAssetFromLocalDiskCall(DiskOnAssetBundleName, AssetBundleObjName, (prefab_) =>
        {
            obj = (GameObject)prefab_;
        }));
        return obj;
    }


    public GameObject ObjLoadCall(string AssetBundleName, string DiskOnAssetBundleName, string AssetBundleObjName)
    {

        GameObject obj = new GameObject();
        //StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName, DiskOnAssetBundleName));
        StartCoroutine(LoadAssetFromLocalDiskCall(DiskOnAssetBundleName, AssetBundleObjName, (prefab_) =>
        {
            obj = (GameObject)prefab_;
        }));
        return obj;
    }

    // 서버에서 받아오고자 하는 에셋 번들의 이름 목록

    // 지금은 간단한 배열 형태를 사용하고 있지만 이후에는

    // xml이나 json을 사용하여 현재 가지고 있는 에셋 번들의 버전을 함께 넣어주고

    // 서버의 에셋 번들 버전 정보를 비교해서 받아오는 것이 좋다.
    public string[] assetBundleNames;

    public IEnumerator SaveAssetBundleOnDisk(string AssetBundleName, string DiskOnAssetBundleName)
    {

        // 에셋 번들을 받아오고자하는 서버의 주소

        // 지금은 주소와 에셋 번들 이름을 함께 묶어 두었지만

        // 주소 + 에셋 번들 이름 형태를 띄는 것이 좋다.
        string uri = BasicUrl + AssetBundleName;
        //Debug.Log(uri);


        // 웹 서버에 요청을 생성한다.
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.Send();



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
    IEnumerator LoadImageAssetFromLocalDisk(string DiskOnAssetBundleName, string AssetBundleObjName)
    {

        //string assetBundleDirectory = "Assets/AssetBundleObj";
        Debug.Log(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
        // 저장한 에셋 번들로부터 에셋 불러오기
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }
        else
            Debug.Log("Successed to load AssetBundle!");


        var prefab = myLoadedAssetBundle.LoadAsset<Texture2D>(AssetBundleObjName);
        viewimage.GetComponent<RawImage>().texture = prefab;

        //Instantiate(prefab, Vector3.zero, Quaternion.identity); 
    }


    IEnumerator LoadImageAssetFromLocalDiskCall(string DiskOnAssetBundleName, string AssetBundleObjName, System.Action<Texture2D> callback)
    {

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

        var prefab = myLoadedAssetBundle.LoadAsset<Texture2D>(AssetBundleObjName);
        Debug.Log(prefab);
        if (prefab != null)
            callback(prefab);
        //Instantiate(prefab, Vector3.zero, Quaternion.identity); 
    }


    ///오브젝트 불러오기
    public IEnumerator LoadAssetFromLocalDiskCall(string DiskOnAssetBundleName, string AssetBundleObjName, System.Action<Object> callback)
    {

        //string assetBundleDirectory = "Assets/AssetBundleObj";
        Object prefab;
        //Debug.Log("in1 : " + AssetBundleObjName);
        // 저장한 에셋 번들로부터 에셋 불러오기
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
        //Debug.Log(assetBundleDirectory + "/" + DiskOnAssetBundleName);
        //Debug.Log("in2 : " + AssetBundleObjName);

        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }
        else
            Debug.Log("Successed to load AssetBundle!");
        if (true)
        {
            // Debug.Log("in3 : " + AssetBundleObjName);
            prefab = myLoadedAssetBundle.LoadAsset(AssetBundleObjName);
            // Debug.Log("in4 : " + AssetBundleObjName);
            callback(prefab);
            //Instantiate(prefab, Vector3.zero, Quaternion.identity);

        }
        myLoadedAssetBundle.Unload(false);

    }
    public GameObject LoadAssetCall(string DiskOnAssetBundleName, string AssetBundleObjName)
    {

        //string assetBundleDirectory = "Assets/AssetBundleObj";
        Object prefab = new GameObject();
        //Debug.Log("in1 : " + AssetBundleObjName);
        // 저장한 에셋 번들로부터 에셋 불러오기
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
        //Debug.Log(assetBundleDirectory + "/" + DiskOnAssetBundleName);
        //Debug.Log("in2 : " + AssetBundleObjName);

        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
        }
        else
            Debug.Log("Successed to load AssetBundle!");
        if (true)
        {
            //Debug.Log("in3 : " + AssetBundleObjName);
            prefab = myLoadedAssetBundle.LoadAsset(AssetBundleObjName);
            //Debug.Log("in4 : " + AssetBundleObjName);
            return (GameObject)prefab;

        }
    }

    ///오브젝트 불러오기
    public IEnumerator LoadAssetFromLocalDiskCall(string DiskOnAssetBundleName, string AssetBundleObjName)//, System.Action<Object> callback)
    {

        //string assetBundleDirectory = "Assets/AssetBundleObj";
        Object prefab;
        // 저장한 에셋 번들로부터 에셋 불러오기
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory + "/", DiskOnAssetBundleName));
        //Debug.Log(assetBundleDirectory + "/" + DiskOnAssetBundleName);

        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }
        else
            Debug.Log("Successed to load AssetBundle!");
        if (true)
        {
            prefab = myLoadedAssetBundle.LoadAsset(AssetBundleObjName);

            //Instantiate(prefab, Vector3.zero, Quaternion.identity);

        }
        myLoadedAssetBundle.Unload(false);

    }

    public IEnumerator testtestests()
    {
        Debug.Log(5);
        yield return new WaitForSeconds(1.0f);
    }


    public void GetAssetBundleInfo()//string bundleName_)
    {
        StartCoroutine(GetAssetBundleManifest());
    }


    //manigest를 통해 종속성 확인
    IEnumerator GetAssetBundleManifest()
    {

        string AssetBundleName = "WinVer";
        string DiskOnAssetBundleName = "WinVer";
        // 에셋 번들을 받아오고자하는 서버의 주소

        // 지금은 주소와 에셋 번들 이름을 함께 묶어 두었지만

        // 주소 + 에셋 번들 이름 형태를 띄는 것이 좋다.
        string uri = BasicUrl + AssetBundleName;
        Debug.Log(BasicUrl);


        // 웹 서버에 요청을 생성한다.
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.Send();



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



        /////////////
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

        AssetBundleManifest prefab = myLoadedAssetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        foreach (var i in prefab.GetAllAssetBundles())
        {
            Debug.Log("test : " + i);
        }
    }



    //여러개의 이미지들을 불러오는 테스트 함수
    IEnumerator GetAssetBundlesImage()
    {
        string AssetBundleName = "mapfileimage";
        string DiskOnAssetBundleName = "mapfileimage";
        // 에셋 번들을 받아오고자하는 서버의 주소

        // 지금은 주소와 에셋 번들 이름을 함께 묶어 두었지만

        // 주소 + 에셋 번들 이름 형태를 띄는 것이 좋다.
        string uri = BasicUrl + AssetBundleName;
        Debug.Log(BasicUrl);


        // 웹 서버에 요청을 생성한다.
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.Send();



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



        /////////////
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

        var prefab = myLoadedAssetBundle.LoadAllAssets();

    }



    //여러개 오브젝트 불러오기
    public Object[] GetBuilderAssetBundleList(string AssetBundleName, string DiskOnAssetBundleName)
    {

        Object[] _prefabs = new Object[5];
        StartCoroutine(SaveAssetBundleOnDisk(AssetBundleName, DiskOnAssetBundleName));
        StartCoroutine(GetBuilderAssetBundleListUP(DiskOnAssetBundleName, (prefab_) =>
        {
            _prefabs = prefab_;
        }));
        //??? 이거 수정 필.

        return _prefabs;
    }

    public IEnumerator GetBuilderAssetBundleListUP(string DiskOnAssetBundleName, System.Action<Object[]> callback)
    {

        // string assetBundleDirectory = "Assets/AssetBundleObj";
        /////////////
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

        var prefab = myLoadedAssetBundle.LoadAllAssets();

        callback(prefab);
        myLoadedAssetBundle.Unload(false);
    }


    public string[] jsonTitleNames()
    {
        string JSONUrl = "http://192.168.0.55:81/MapTest/MapJson/jsonTitleNames.txt";
        string[] jsonNames = new string[10];
        StartCoroutine(GetJsonNames((_namesJson) =>
        {
            //jsonNames = _namesJson;
            JSONUrl = _namesJson;

        }));

        return jsonNames;
    }
    public IEnumerator GetJsonNames(System.Action<string> callback)
    {

        string jsonUrl = "http://192.168.0.55:81/MapTest/MapJson/jsonTitleNames.txt";
        string[] jsonNames = new string[1];
        UnityWebRequest www = UnityWebRequest.Get(jsonUrl);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            //Debug.Log("result : " + www.downloadHandler.text);
            //jsonNames = www.downloadHandler.text.Split('\n');

            callback(www.downloadHandler.text);
        }

    }


}