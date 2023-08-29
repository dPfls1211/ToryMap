using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class viewImage : MonoBehaviour, IPointerClickHandler
{
    public Texture2D[] testSprite;
    int i = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<RawImage>().texture = testSprite[i++ % 8];
    }
}
