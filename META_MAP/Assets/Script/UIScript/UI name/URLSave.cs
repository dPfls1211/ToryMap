using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class URLSave : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField input_url;
 
    public bool changeURL = false;
    public string saveURL="";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

    
    }
    public void OnButtonClick(){
        panel.SetActive(true);
    }
    public void OnBTN_X(){
        panel.SetActive(false);
    }
    public void Input(){
        saveURL = input_url.text;
        changeURL=true;
    }
}
