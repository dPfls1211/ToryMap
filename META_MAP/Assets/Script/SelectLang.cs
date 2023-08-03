using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SelectLang : MonoBehaviour
{
    public List<GameObject> langs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickLang()
    {
        foreach (var lang in langs)
        {
            lang.transform.GetChild(0).GetComponent<TMP_Text>().fontStyle = FontStyles.Normal;
            lang.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(227, 227, 227, 255);
            // Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(255, 255, 255, 255);


        }
    }
}
