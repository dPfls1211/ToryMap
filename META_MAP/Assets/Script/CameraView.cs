using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    GameObject gam;
    UIName parent_pos;
    public Transform[] Obj_List_child_transform;
    private Camera cam;
    int len=0;

    // Start is called before the first frame update
    void Start()
    {
        gam = GameObject.Find("Main Camera").transform.parent.gameObject;
        parent_pos = gam.GetComponent<UIName>();
        Obj_List_child_transform = parent_pos.Obj_List_child_transform;
        len = Obj_List_child_transform.Length;
        
        cam = UnityEngine.Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
    }
   
}
