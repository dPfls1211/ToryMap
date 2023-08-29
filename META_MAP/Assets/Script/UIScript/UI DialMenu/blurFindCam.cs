using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blurFindCam : MonoBehaviour
{
    private void Start()
    {

        transform.GetComponent<Canvas>().worldCamera = DontDestioryObj.instance.camera_main.GetComponent<Camera>();
        transform.GetComponent<Canvas>().planeDistance = 500;
    }
}
