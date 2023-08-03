using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class AssetbundleLoading : MonoBehaviour
{
    public static float AssetBundleLoadingProgress = 0;

    [SerializeField]
    Image progressBar;

    float timer = 0.0f;

    public static AssetbundleLoading instance;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (AssetBundleLoadingProgress < 0.9f)
        {
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, AssetBundleLoadingProgress, timer);
            if (progressBar.fillAmount >= AssetBundleLoadingProgress)
            {
                timer = 0f;
            }
        }
        else
        {

            if (AssetBundleLoadingProgress >= 0.95f)
            {

                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1.0f, timer);
            }
            if (progressBar.fillAmount == 1.0f)
            {
                GameObject.Find("GameObject").GetComponent<loadTest>().Load();
                StartCoroutine(waitLoading());
            }
        }
    }

    IEnumerator waitLoading()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        gameObject.SetActive(false);
    }
}
