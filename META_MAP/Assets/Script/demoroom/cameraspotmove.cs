using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cameraspotmove : MonoBehaviour
{
    public GameObject spot;
    public GameObject sensor;
    int spotlen;

    Transform[] spotlist;
    Camera cam;
    bool ismoving = false;
    string clickobjname;
    GameObject clickobj;

    float xmove = 0;
    float ymove = 0;
    float originEulerAnglesY;

    public Texture[] img;
    private void Awake()
    {
        cam = Camera.main;
        sensor = GameObject.Find("Canvas").transform.GetChild(0).transform.gameObject;
    }
    void Start()
    {
        originEulerAnglesY = transform.eulerAngles.x;
        GetTopLevelChildrenName(spot);
        spotlen = spotlist.Length;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;

                try
                {
                    if (click_obj.GetComponent<pointType>().thistype == pointType.Type.spot)
                    {
                        ismoving = true;
                        clickobjname = click_obj.name;
                        clickobj = click_obj.transform.GetChild(0).transform.gameObject;
                    }
                    else if (click_obj.GetComponent<pointType>().thistype == pointType.Type.mideaboard)
                    {
                        sensor.SetActive(true);
                        sensorType.Typesensor type = click_obj.GetComponent<sensorType>().thistype;
                        switch (type)
                        {
                            case sensorType.Typesensor.smartriverservice:
                                sensor.transform.GetChild(0).transform.gameObject.GetComponent<RawImage>().texture = img[0];
                                break;
                            case sensorType.Typesensor.riversafeservice:
                                sensor.transform.GetChild(0).transform.gameObject.GetComponent<RawImage>().texture = img[0];
                                break;
                        }


                    }
                }
                catch
                {

                }

            }
        }
        if (ismoving)
        {
            this.GetComponent<cam360_2>().iscancontroll = false;
            clickpoint(clickobjname);
        }
    }


    private void GetTopLevelChildrenName(GameObject parentObject)
    {
        spotlist = new Transform[parentObject.transform.childCount];
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            spotlist[i] = parentObject.transform.GetChild(i).transform.GetChild(0).transform;
        }
    }

    public void clickpoint(string num)
    {
        int n = int.Parse(num);
        cam.transform.position = Vector3.Lerp(cam.transform.position, spotlist[n].transform.position, Time.deltaTime * 4.0f);
        cam.transform.rotation = Quaternion.Lerp(transform.rotation, spotlist[n].transform.rotation, Time.deltaTime * 4.0f);

        float dis = Vector3.Distance(transform.position, clickobj.transform.position);

        if (dis < 0.004f)
        {
            ismoving = false;
            this.GetComponent<cam360_2>().iscancontroll = true;
        }
    }

}
