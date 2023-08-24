using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam360 : MonoBehaviour
{
    public bool canvasClickedCheck = false;
    public bool touchcheck = true;
    public float speed = 1;

    float xmove = 0;
    // Update is called once per frame
    void Update()
    {
        if (!canvasClickedCheck)
        {
            if (touchcheck)
                touchscreenRotation();
            else
                mouseclickedRotation();

        }
    }


    void mouseclickedRotation()
    {
        if (Input.GetMouseButton(1))
        {
            xmove = Input.GetAxis("Mouse X");
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, xmove * speed, 0);
        }
    }


    private Vector2 nowPos, prePos;
    private Vector2 movePosDiff;
    void touchscreenRotation()
    {
        if (Input.touchCount == 1)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePosDiff = (Vector2)(prePos - nowPos) * Time.deltaTime;
                prePos = touch.position - touch.deltaPosition;
            }


            xmove = movePosDiff.x;

            transform.eulerAngles = transform.eulerAngles + new Vector3(0, xmove * speed, 0);


        }
    }


}
