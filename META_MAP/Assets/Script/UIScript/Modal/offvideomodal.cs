using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class offvideomodal : MonoBehaviour
{
    bool iscanbreak = false;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            foreach (var i in results)
            {
                if (i.gameObject.name == "contents_box")
                    iscanbreak = true;
            }
            if (iscanbreak)
            {
                this.gameObject.SetActive(false);
                iscanbreak = false;
            }
        }
    }
}
