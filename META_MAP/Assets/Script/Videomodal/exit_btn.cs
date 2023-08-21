using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_btn : MonoBehaviour
{


    public void exit_btnclick()
    {
        StartCoroutine("waittwo");
    }
    public void onrecode_modal()
    {
        openModal.recodemodal.SetActive(true);
    }
    IEnumerator waittwo()
    {
        yield return new WaitForSeconds(0.3f);
        open_videomodal.videomodalon = false;
        gameObject.SetActive(false);
    }
}
