using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class main_toolkit : MonoBehaviour
{
    struct typelists
    {
        public obj_Type.obj_type type;
        public GameObject[] OBJlist;
        public int listlen;
        public string[] origin_Kor;
        public string[] origin_Eng;
        public string[] change_Kor;
        public string[] change_Eng;
    }

    public VisualTreeAsset uiAsset;
    TextField textField;
    VisualElement root;
    VisualElement tablevisual;
    VisualElement maketable;
    obj_Type.obj_type objtype;
    GameObject map;


    GameObject[] typelist;


    typelists[] list;




    private void Awake()
    {
        map = GameObject.Find("MAP");

        root = GetComponent<UIDocument>().rootVisualElement;
        tablevisual = root.Q("tableVisual");
    }

    void Start()
    {

        makeui();
        makeobjtable();

        //textField.value = "안녕하세요";
    }

    void initmainvalue()
    {
    }
    void makeui() //필요 ui생성
    {
        GetTopLevelChildrenName(map);
        int typelen = typelist.Length;

        list = new typelists[typelen];
        for (int i = 0; i < typelen; i++)
        {
            if (typelist[i].GetComponent<obj_Type>().objtype == obj_Type.obj_type.other)
            {
                list[i].type = obj_Type.obj_type.other;
                continue;
            }
            if (typelist[i].GetComponent<obj_Type>().objtype == obj_Type.obj_type.building)
            {
                list[i].type = obj_Type.obj_type.building;
            }
            else if (typelist[i].GetComponent<obj_Type>().objtype == obj_Type.obj_type.image)
            {
                list[i].type = obj_Type.obj_type.image;

            }
            else if (typelist[i].GetComponent<obj_Type>().objtype == obj_Type.obj_type.video)
            {
                list[i].type = obj_Type.obj_type.video;

            }
            list[i].listlen = typelist[i].transform.childCount;
            list[i].OBJlist = new GameObject[list[i].listlen];
            for (int j = 0; j < list[i].listlen; j++)
            {
                list[i].OBJlist[j] = typelist[i].transform.GetChild(j).transform.gameObject;
            }
        }

    }
    void makeobjtable()
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].type == obj_Type.obj_type.building)
            {
                saveorigin(list[i]);
            }
        }
    }
    void saveorigin(typelists typelist)
    {
        typelist.origin_Kor = new string[typelist.listlen];
        typelist.origin_Eng = new string[typelist.listlen];
        Debug.Log(typelist.listlen);
        for (int i = 0; i < typelist.listlen; i++)
        {
            typelist.origin_Kor[i] = typelist.OBJlist[i].GetComponent<ObjSetUi>().objName;
            typelist.origin_Eng[i] = typelist.OBJlist[i].GetComponent<ObjSetUi>().objEngName;
            tablevisual.Add(uiAsset.Instantiate());
            maketable = root.Q("tableRowContents_order");
            maketable.name = "tableRowContents_order_" + typelist.origin_Eng[i];

            //root.Q("tableRowContents_order_" + typelist.origin_Eng[i]).style.backgroundColor = Color.black;
            textField = maketable.Q<TextField>("InputitemBoxName_kor");
            textField.value = typelist.origin_Kor[i];
            textField = maketable.Q<TextField>("InputitemBoxName_eng");
            textField.value = typelist.origin_Eng[i];
        }
    }

    private void GetTopLevelChildrenName(GameObject parentObject)
    {
        typelist = new GameObject[parentObject.transform.childCount];
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            typelist[i] = parentObject.transform.GetChild(i).transform.gameObject;
        }
    }

}
