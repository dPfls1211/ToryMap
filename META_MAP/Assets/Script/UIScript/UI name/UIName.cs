using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;


public class UIName : MonoBehaviour
{
    public GameObject Obj_list_parent;   //object그룹
    public GameObject UI_Name;

    public Transform UI_NameCanvas;
    public Transform[] Obj_List_child_transform;
    public List<GameObject> UI_child_list;

    GameObject camera;

    public int objlen = 0;
    public LocalizeStringEvent localizeStringEvent;



    private void Awake()
    {
        GetTopLevelChildrenName(Obj_list_parent.gameObject);
        objlen = Obj_List_child_transform.Length;
        UI_child_list = new List<GameObject>();
        camera = GameObject.Find("Main Camera");
        CreateNamePanel();
    }


    // Update is called once per frame
    void Update()
    {
        //LookPlayer();

    }
    void CreateNamePanel()
    {
        Debug.Log(languageChange.langsetting);
        for (int i = 0; i < objlen; i++)
        {
            GameObject ins = Instantiate(UI_Name);
            ins.transform.SetParent(UI_NameCanvas, true);
            localizeStringEvent = ins.transform.GetChild(1).GetComponent<LocalizeStringEvent>();
            localizeStringEvent.StringReference.TableEntryReference = Obj_List_child_transform[i].name + "_key";

            ins.name = Obj_List_child_transform[i].name;
            ins.transform.position = new Vector3(Obj_List_child_transform[i].position.x, Obj_List_child_transform[i].position.y + 2.0f, Obj_List_child_transform[i].position.z);
            UI_child_list.Add(ins);
            ins.GetComponentInChildren<TMP_Text>().text = Obj_List_child_transform[i].name;

        }
    }

    public void changeUI(int num)
    {
        Debug.Log(UI_child_list[0]);
        for (int i = 0; i < objlen; i++)
        {
            UI_child_list[i].transform.GetChild(0).GetComponent<set_UI_background>().resizeUI();
        }
        if (num == 0)
        {
            set_UI_background.oneeng = false;
        }
        else if (num == 1)
        {
            set_UI_background.onekor = false;
        }
    }

    void LookPlayer()
    {
        Vector3 lookcamera = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
        for (int i = 0; i < objlen - 1; i++)
        {
            UI_child_list[i].transform.LookAt(lookcamera);
            Vector3 rote = camera.transform.eulerAngles;
            UI_child_list[i].transform.eulerAngles = rote;
        }
    }
    private void GetTopLevelChildrenName(GameObject parentObject)
    {
        Obj_List_child_transform = new Transform[parentObject.transform.childCount];
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            Obj_List_child_transform[i] = parentObject.transform.GetChild(i).transform;
        }
    }
}
