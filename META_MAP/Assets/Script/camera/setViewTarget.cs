using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class setViewTarget : MonoBehaviour
{
    Vector3 objBasicTransform;
    camera_Event targetMainCameraActionSC;

    ObjSetUi setUIcontents;
    int sign = 1;
    int sizeCount = 0;
    int sizeTotalCount = 0;
    public static bool zoomCheck = false;

    public static UIexplain localUIControlCs;
    public static UIExplain_ver3 explain3;

    public static GameObject myOBJ = null;
    // Start is called before the first frame update

    void Start()
    {
        setUIcontents = gameObject.GetComponent<ObjSetUi>();
        objBasicTransform = gameObject.transform.localScale;
        targetMainCameraActionSC = GameObject.Find("Main Camera").GetComponent<camera_Event>();
        localUIControlCs = GameObject.Find("UI_NAME_Canvas").GetComponent<UIexplain>();
        explain3 = GameObject.Find("info_toolkit").GetComponent<UIExplain_ver3>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    //객체 마우스 오버 시 바운스 
    private void OnMouseEnter()  //
    {
    }

    private void OnMouseExit()
    {
        //StopAllCoroutines();
        this.transform.localScale = objBasicTransform;
        sizeCount = 0;
        sizeTotalCount = 0;
    }

    IEnumerator ScaleControl()
    {

        this.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f) * sign;
        sizeCount++;
        sizeTotalCount++;
        if (sizeCount > 10)
        {
            sizeCount = 0;
            sign = -sign;
        }
        if (sizeTotalCount > 20)
        {
            sizeTotalCount = 0;
            yield break;
        }
        yield return new WaitForSeconds(0.05f);
    }


    private void OnMouseDown()
    {
        EnterBtnLoadScene.LoadScenename = gameObject.transform.GetComponent<ObjSetUi>().nextScene;
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            StartCoroutine(zoomInViewOBJ());
            if (myOBJ == gameObject)
            {
                explain3.click(myOBJ);
            }
            else
            {
                if (myOBJ != null)
                {
                    explain3.infoOff();
                }

                myOBJ = gameObject;
                explain3.click(myOBJ);

            }
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                targetMainCameraActionSC.TargetObject = gameObject;
                targetMainCameraActionSC.checkedCamReset = false;
                Camera Mcam = GameObject.Find("Main Camera").GetComponent<Camera>();
                Mcam.fieldOfView = 26f;
                Mcam.nearClipPlane = 1.25f;
                Mcam.farClipPlane = 50;

                zoomCheck = true;
            }
        }



    }


    private void OnTouchFuc()
    {
        EnterBtnLoadScene.LoadScenename = gameObject.transform.GetComponent<ObjSetUi>().nextScene;
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            //StartCoroutine(zoomInViewOBJ());
            if (myOBJ == gameObject)
            {
                explain3.click(myOBJ);
            }
            else
            {
                if (myOBJ != null)
                {
                    explain3.infoOff();
                }

                myOBJ = gameObject;
                explain3.click(myOBJ);

            }
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                targetMainCameraActionSC.TargetObject = gameObject;
                targetMainCameraActionSC.checkedCamReset = false;
                GameObject.Find("Main Camera").GetComponent<Camera>().fieldOfView = 26f;

                zoomCheck = true;
            }
        }



    }


    public void ShowExplaneUI()
    {
        // GameObject uiExplaneCanvas = GameObject.Find("ExplaneUICanvas").GetComponent<childcheck>().ExplaneUICanvas;
        // uiExplaneCanvas.SetActive(true);

        // uiExplaneCanvas.GetComponent<UIVisible>().OBJname = setUIcontents.objName;
        // uiExplaneCanvas.GetComponent<UIVisible>().objExplane_ = setUIcontents.objExplane;
        // uiExplaneCanvas.GetComponent<UIVisible>().AssetAddress = setUIcontents._address;
        // if (setUIcontents._phonenum == null)
        //     uiExplaneCanvas.GetComponent<UIVisible>().phoneNum = " ";
        // else
        // {
        //     uiExplaneCanvas.GetComponent<UIVisible>().phoneNum = setUIcontents._phonenum;

        // }
        // UIVisible.explaneUrl = setUIcontents._explaneUrl;
        // uiExplaneCanvas.GetComponent<UIVisible>().SetUICan();
    }


    IEnumerator zoomInViewOBJ()
    {
        yield return new WaitForSeconds(3.0f);

        //Debug.Log(gameObject);
        SetUIZoomObj.zoomInTargetObj = gameObject;
        GameObject.Find("objImage_zoomExplane").GetComponent<SetUIZoomObj>().viewTargetObj();
    }

}
