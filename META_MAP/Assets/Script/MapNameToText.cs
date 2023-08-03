using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapNameToText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMP_Text>().text = gameObject.transform.parent.name;
    }

}
