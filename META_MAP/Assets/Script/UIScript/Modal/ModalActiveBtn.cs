using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalActiveBtn : MonoBehaviour
{
    public GameObject modal;

    public void hiddenModal()
    {
        modal.SetActive(false);
    }

    public void showModal()
    {
        modal.SetActive(true);
    }
}
