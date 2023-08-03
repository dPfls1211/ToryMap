using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRenderer : MonoBehaviour
{
    UIExplain_ver3 ex;
    LineRenderer linerender;
    // Start is called before the first frame update
    void Start()
    {
        ex = GameObject.Find("Info_Canvas").GetComponent<UIExplain_ver3>();
        linerender = GetComponent<LineRenderer>();

        linerender.positionCount = 2;
        linerender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void drawline(Vector3 start, Vector3 end)
    {
        linerender.enabled = true;

        linerender.SetPosition(0, start);
        linerender.SetWidth(10, 10);
        linerender.sortingOrder = 5;
        linerender.SetPosition(1, end);
    }
}
