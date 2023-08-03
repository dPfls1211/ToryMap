using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIName : MonoBehaviour
{
    public GameObject Obj_list_parent;
    public GameObject UI_Name;

    public Transform UI_NameCanvas;
    public Transform[] Obj_List_child_transform;
    public List<GameObject> UI_child_list;
    List<GameObject> UI_explain_child_list;

    GameObject camera;

    public int objlen = 0;



    private void Awake()
    {
        GetTopLevelChildrenName(Obj_list_parent.gameObject);
        objlen = Obj_List_child_transform.Length;
        UI_child_list = new List<GameObject>();
        UI_explain_child_list = new List<GameObject>();
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
        for (int i = 0; i < objlen; i++)
        {
            GameObject ins = Instantiate(UI_Name);
            ins.transform.SetParent(UI_NameCanvas, true);
            ins.name = Obj_List_child_transform[i].name;
            ins.transform.position = new Vector3(Obj_List_child_transform[i].position.x, Obj_List_child_transform[i].position.y + 12.0f, Obj_List_child_transform[i].position.z);
            UI_child_list.Add(ins);
            ins.GetComponentInChildren<TMP_Text>().text = Obj_List_child_transform[i].name;

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
