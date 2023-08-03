using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class showSidebar : MonoBehaviour,  IPointerClickHandler
{
    public GameObject sidebarObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        sidebarObj.GetComponent<sideBarAnimation>().checkViewSideBar=true;
    }
}
