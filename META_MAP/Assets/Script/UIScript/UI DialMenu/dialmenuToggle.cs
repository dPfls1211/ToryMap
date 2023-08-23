using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class dialmenuToggle : MonoBehaviour, IPointerClickHandler
{
    public GameObject dialMenu_toggleTarget;
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
        dialMenu_toggleTarget.GetComponent<dialmenuAni>().showDialmenu = !dialMenu_toggleTarget.GetComponent<dialmenuAni>().showDialmenu;
        dialMenu_toggleTarget.GetComponent<dialmenuAni>().opacitySpeed = 0.01f;
    }
}
