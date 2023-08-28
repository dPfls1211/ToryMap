using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_btn : MonoBehaviour
{

    public void exit_btn_click()
    {
        gameObject.SetActive(false);
    }
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
        open_videomodal.videomodalon = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
