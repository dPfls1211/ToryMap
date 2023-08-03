using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sidebar_onoff : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sidebar_view;

    public Texture onimage;
    public Texture offimage;
    public bool ison = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void checkbool()
    {
        if (ison)
        {
            offSidebar_view();
        }
        else
        {
            onsidebar_view();
        }
    }

    void offSidebar_view()
    {
        sidebar_view.SetActive(false);
        ison = false;
        this.GetComponent<RawImage>().texture = offimage;
    }
    void onsidebar_view()
    {
        sidebar_view.SetActive(true);
        ison = true;
        this.GetComponent<RawImage>().texture = onimage;
    }
}
