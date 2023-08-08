using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_cms : MonoBehaviour
{
    GameObject sidebar;
    void Awake()
    {
        sidebar = GameObject.Find("Sidebar_final0808");
        sidebar.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
    }
}
