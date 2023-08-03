using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatMe : MonoBehaviour
{
    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera);
        // transform.Rotate(new Vector3(90, 0, 0));  ///title 전용 회전.
    }
}
