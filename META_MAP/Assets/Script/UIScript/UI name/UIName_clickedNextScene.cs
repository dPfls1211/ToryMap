using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class UIName_clickedNextScene : MonoBehaviour, IPointerClickHandler
{
    public string nextSceneNameUI = null;
    public GameObject basicObj;

    public void OnPointerClick(PointerEventData eventData)
    {
        // //LoadingSceneManager.LoadScene(nextSceneNameUI);
        // string[] name_ui = gameObject.name.Split('-');
        // Debug.Log(name_ui[0]);
        // GameObject.Find(name_ui[0]).GetComponent<setViewTarget>().ClickedObj(GameObject.Find(name_ui[0]));
    }
}
