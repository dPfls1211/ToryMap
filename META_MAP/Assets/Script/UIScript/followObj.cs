using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObj : MonoBehaviour
{
    GameObject gam;
    UIName parent_pos;
    int len;
    public Transform[] Obj_List_child_transform;
    public Transform[] child_transform;
    Camera cam;

    public int[] objlook;

    float nameposy = 0.7f;
    public bool namechangepos = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        GetTopLevelChildrenName(this.gameObject);
        gam = GameObject.Find("Main Camera").transform.parent.gameObject;
        parent_pos = gam.GetComponent<UIName>();
        Obj_List_child_transform = parent_pos.Obj_List_child_transform;
        len = Obj_List_child_transform.Length;
        objlook = new int[len];
    }

    // Update is called once per frame
    void Update()
    {
        follow();

        check_objislook();
        UI_ON();
        if (Input.GetMouseButtonDown(0))
        {
        }

    }
    void follow()
    {
        for (int i = 0; i < len; i++)
        {
            child_transform[i].position = cam.WorldToScreenPoint(new Vector3(Obj_List_child_transform[i].position.x, Obj_List_child_transform[i].position.y + nameposy, Obj_List_child_transform[i].position.z));
        }
    }
    private void GetTopLevelChildrenName(GameObject parentObject)  //캔버스 하위객체
    {
        child_transform = new Transform[parentObject.transform.childCount];
        for (int i = 0; i < parentObject.transform.childCount - 1; i++)
        {
            child_transform[i] = parentObject.transform.GetChild(i + 1).transform;
        }
    }

    //ui_explain_ver1
    public void namemove()
    {
        if (!namechangepos)
        {
            nameposy = 0.0f;
        }
        else
        {
            nameposy = 0.0f;
        }
    }



    void UI_ON()
    {
        for (int i = 0; i < len; i++)
        {
            if (objlook[i] == 1)
            {
                child_transform[i].gameObject.SetActive(true);
            }
            else
            {
                child_transform[i].gameObject.SetActive(false);

            }
        }
    }

    public void check_objislook()
    {
        for (int i = 0; i < len; i++)
        {

            Vector3 viewPos = cam.WorldToViewportPoint(Obj_List_child_transform[i].position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {

                //Debug.Log($"Camera in object: {Obj_List_child_transform[i].name}");
                objlook[i] = 1;
            }
            else
            {
                objlook[i] = 0;
            }
        }
    }

}
