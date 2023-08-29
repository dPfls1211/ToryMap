using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kiosk : MonoBehaviour
{
    public Texture main;
    public Texture main_mini;
    public Texture main_poster;
    public Texture storemap;
    public Texture storelist;
    public Texture storeinfo;
    public Texture sensordust;
    public Texture sensorwater;

    public GameObject kioskimg;
    public GameObject closbtn;

    public GameObject publicarea;
    public GameObject clickarea;
    public GameObject clickstorearea;
    public GameObject clicksensor;
    float x = -2.0f;
    float y = -129.0f;
    float z = -0.6f;

    float[] miniclose = { -2.0f, -129.0f, -0.6f };
    float[] posterclose = { -5.0f, -202.2f, -0.8f };
    float[] storeclose = { -4.0f, -187.9f, -0.8f };

    string nowpage = "main";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gomain()
    {
        publicarea.SetActive(true);
        kioskimg.GetComponent<RawImage>().texture = main;
        clickarea.SetActive(true);
        clickstorearea.SetActive(false);
        clicksensor.SetActive(false);
        nowpage = "main";
    }
    public void main_main()
    {
        kioskimg.GetComponent<RawImage>().texture = main_mini;
        closbtn.SetActive(true);
        clickarea.SetActive(false);
        publicarea.SetActive(false);
        closbtn.transform.localPosition = new Vector3(miniclose[0], miniclose[1], miniclose[2]);
    }
    public void mainposter()
    {
        kioskimg.GetComponent<RawImage>().texture = main_poster;
        closbtn.SetActive(true);
        clickarea.SetActive(false);
        publicarea.SetActive(false);
        closbtn.transform.localPosition = new Vector3(posterclose[0], posterclose[1], posterclose[2]);
    }
    public void storemap1()
    {
        clickarea.SetActive(false);
        clickstorearea.SetActive(true);
        clicksensor.SetActive(false);
        kioskimg.GetComponent<RawImage>().texture = storemap;
        nowpage = "store";
    }
    public void storelist1()
    {
        kioskimg.GetComponent<RawImage>().texture = storelist;
    }
    public void storeinfo1()
    {
        kioskimg.GetComponent<RawImage>().texture = storeinfo;
        closbtn.SetActive(true);
        closbtn.transform.localPosition = new Vector3(storeclose[0], storeclose[1], storeclose[2]);
    }
    public void sensordust1()
    {
        kioskimg.GetComponent<RawImage>().texture = sensordust;
        clicksensor.SetActive(true);
    }
    public void sensorwater1()
    {
        kioskimg.GetComponent<RawImage>().texture = sensorwater;
    }
    public void closemain()
    {
        if (nowpage == "main")
        {
            kioskimg.GetComponent<RawImage>().texture = main;
            clickarea.SetActive(true);
            clickstorearea.SetActive(false);
            nowpage = "main";
        }
        else if (nowpage == "store")
        {
            kioskimg.GetComponent<RawImage>().texture = storemap;
            clickstorearea.SetActive(true);
        }
        publicarea.SetActive(true);
        closbtn.SetActive(false);

    }
    public void clickmainin()
    {
        clickarea.SetActive(false);
    }
    public void storeinfoclose()
    {
        kioskimg.GetComponent<RawImage>().texture = storemap;
        clickstorearea.SetActive(false);
    }

}
