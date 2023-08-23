using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam360 : MonoBehaviour
{
    public bool canvasClickedCheck = false;
    public float speed = 1;

    float xmove = 0;
    // Update is called once per frame
    void Update()
    {
        if (!canvasClickedCheck)
        {
            if (Input.GetMouseButton(1))
            {
                xmove = Input.GetAxis("Mouse X");
                transform.eulerAngles = transform.eulerAngles + new Vector3(0, xmove * speed, 0);
            }
        }
    }

}
