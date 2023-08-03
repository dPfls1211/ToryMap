using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickViewModal : MonoBehaviour
{
    GameObject viewModal;
    // Start is called before the first frame update
    void Awake()
    {
        viewModal = GameObject.Find("VideoCanvas").transform.GetChild(0).gameObject;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            viewModal.SetActive(true);
    }
}
