using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRotate : MonoBehaviour
{

    public float speed = 0.4f;  // 속도
    public float limitY = 4.0f;
    float overy = 0;
    float downy = 0;
    float calY = 0;
    bool right = true;
    float startY = 0;
    public bool isTurn = true;
    bool upok = true;
    bool downok = true;
    void Awake()
    {
        startY = transform.rotation.eulerAngles.y;


        if (startY + limitY >= 360)
        {
            upok = false;
            overy = (startY + limitY) - 360;
        }
        else
        {
            overy = startY + limitY;
        }

        if (startY - limitY >= 0)
        {
            downy = startY - limitY;
        }
        else
        {
            downok = false;
            downy = 360 + (startY - limitY);
        }

    }
    void FixedUpdate()
    {
        startY = transform.rotation.eulerAngles.y;

        if (startY - overy >= -0.1 && startY - overy <= 0.1 && right)
        {
            right = false;
        }
        if (startY - downy <= 0.1 && startY - downy >= -0.1 && !right)
        {
            right = true;
        }
        if (right)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            transform.Rotate(Vector3.down * Time.deltaTime * speed);
        }

    }

}
