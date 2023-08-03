using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class sideBarAnimation : MonoBehaviour, IPointerClickHandler
{
    public Texture hamburgericon;
    public Texture arrowlefticon;

    public float lerpTime = 0.3f;
    float currentTime = 0;

    public GameObject sidebarObj;
    public bool checkViewSideBar = true;
    private RectTransform rectTransform;

    Vector2 Target_position;
    Vector2 orign_position;
    // Start is called before the first frame update
    void Start()
    {

        rectTransform = sidebarObj.GetComponent<RectTransform>();

        orign_position = sidebarObj.GetComponent<RectTransform>().anchoredPosition;
        Debug.Log(orign_position);
        Target_position = new Vector2(-orign_position.x, orign_position.y);
        if (!checkViewSideBar)
        {
            sidebarObj.GetComponent<RectTransform>().anchoredPosition = Target_position;
            GetComponent<RawImage>().texture = hamburgericon;

        }
        else
        {
            GetComponent<RawImage>().texture = arrowlefticon;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!checkViewSideBar)
        {
            sidebarObj.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(sidebarObj.GetComponent<RectTransform>().anchoredPosition, Target_position, 0.3f);

        }
        else
        {
            sidebarObj.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(sidebarObj.GetComponent<RectTransform>().anchoredPosition, orign_position, 0.3f);

        }
    }

    private void OnMouseDown()
    {
        currentTime = 0;
        checkViewSideBar = !checkViewSideBar;
        if (checkViewSideBar)
            GetComponent<RawImage>().texture = arrowlefticon;
        else
        {
            GetComponent<RawImage>().texture = hamburgericon;
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        currentTime = 0;

        checkViewSideBar = !checkViewSideBar;
        if (checkViewSideBar)
            GetComponent<RawImage>().texture = arrowlefticon;
        else
        {
            GetComponent<RawImage>().texture = hamburgericon;
        }

    }

}
