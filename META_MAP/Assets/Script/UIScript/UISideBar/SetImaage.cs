using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImaage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RawImage>().texture =  DontDestioryObj.instance.image_mainBackground;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
