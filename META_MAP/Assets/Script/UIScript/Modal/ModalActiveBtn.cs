using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModalActiveBtn : MonoBehaviour
{
    public GameObject modal;

    public void hiddenModal()
    {
        Debug.Log("!!");
        modal.SetActive(false);
    }

    public void showModal()
    {
        modal.SetActive(true);
    }

}
