using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class openModal : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject recodemodal;
    public bool one = true;
    private void Awake()
    {
        recodemodal = GameObject.Find("recode_modal").transform.GetChild(0).transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                recodemodal.SetActive(true);
                if (one)
                    recodemodal.GetComponent<SetmodalContents>().makerender();
                one = false;
            }
        }
    }
    public void closemodal()
    {
        recodemodal.SetActive(false);

    }
}
