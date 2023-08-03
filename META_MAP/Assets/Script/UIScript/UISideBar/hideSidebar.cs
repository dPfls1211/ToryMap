using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class hideSidebar : MonoBehaviour, IPointerClickHandler
{
    public GameObject _sidebar;
    public bool checkViewSidebar = true;
    Vector3 Target_position;
    Vector3 orign_position;
    // Start is called before the first frame update
    void Start()
    {
        orign_position=_sidebar.transform.position;
        Target_position = new Vector3(-700,541,243);
    }

    // Update is called once per frame
    void Update()
    {
        if(!checkViewSidebar){
            _sidebar.transform.position = Vector3.Lerp(_sidebar.transform.position,Target_position,0.1f);
        
        }{
            _sidebar.transform.position = Vector3.Lerp(_sidebar.transform.position,orign_position,0.1f);
            
        }
    }

    private void OnMouseDown() {
        checkViewSidebar=false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        checkViewSidebar=false;
    }
}
