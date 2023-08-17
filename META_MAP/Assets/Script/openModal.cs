using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openModal : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject recodemodal;
    private void Awake()
    {
        recodemodal = GameObject.Find("recode_modal").transform.GetChild(0).transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                recodemodal.SetActive(true);
                Debug.Log(click_obj);
            }
        }
    }
}
