using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeSeletedModelName : MonoBehaviour
{

    public static string SeletedModelName = "None";
    // Start is called before the first frame update
    void Start()
    {
        SeletedModelName = "None";
        ModelNameView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModelNameView(){
        gameObject.transform.GetComponent<TextMeshProUGUI>().text = SeletedModelName;
    }
}
