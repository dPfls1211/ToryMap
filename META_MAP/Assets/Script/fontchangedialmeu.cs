using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fontchangedialmeu : MonoBehaviour
{
    public string ToChangeEng;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void toChangeFontEng()
    {
        transform.GetComponent<TMP_Text>().text = ToChangeEng;
    }
}
