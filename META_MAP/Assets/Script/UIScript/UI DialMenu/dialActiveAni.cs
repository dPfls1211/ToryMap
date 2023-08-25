using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialActiveAni : MonoBehaviour
{
    public static float rotationAngle = 0;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(gameObject.GetComponent<RectTransform>().rotation.x, gameObject.GetComponent<RectTransform>().rotation.y, gameObject.GetComponent<RectTransform>().rotation.z + rotationAngle);
        gameObject.GetComponent<RectTransform>().rotation = Quaternion.Slerp(gameObject.GetComponent<RectTransform>().rotation, Quaternion.Euler(0, 0, rotationAngle), 0.1f);
    }
}
