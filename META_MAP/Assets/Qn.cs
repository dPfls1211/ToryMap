using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Qn : MonoBehaviour, IPointerClickHandler
{
    public GameObject ui;

    bool test = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ui.SetActive(test);
        test = !test;
    }
}
