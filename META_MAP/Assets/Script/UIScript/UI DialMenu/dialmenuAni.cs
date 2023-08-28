using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialmenuAni : MonoBehaviour
{
    public bool showDialmenu = false;
    public GameObject blurBackground;
    public GameObject toggleHandler;

    public GameObject hideDialmenuOBJ;
    public GameObject showDialmenuOBJ;
    public GameObject showDialmenuIcon;
    public GameObject shadowObj;
    public GameObject donttouchOBJ;
    List<Transform> showDialmenuIcons = new List<Transform>();


    private RectTransform rectTransform;

    Vector2 Target_position;
    Vector2 orign_position;
    Vector2 blurTarget_position;
    Vector2 blurorign_position;

    Vector2 toggleTarget_position;
    Vector2 toggleorigin_position;

    public float opacitySpeed = 0.01f;
    float opacity = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(showDialmenuIcon.transform.childCount);
        for (int i = 0; i < showDialmenuIcon.transform.childCount; i++)
        {
            showDialmenuIcons.Add(showDialmenuIcon.transform.GetChild(i));
        }
        rectTransform = gameObject.GetComponent<RectTransform>();

        orign_position = gameObject.GetComponent<RectTransform>().anchoredPosition;
        blurorign_position = blurBackground.GetComponent<RectTransform>().anchoredPosition;
        toggleorigin_position = toggleHandler.GetComponent<RectTransform>().anchoredPosition;
        Target_position = new Vector2(orign_position.x, orign_position.y - 280);

        toggleTarget_position = new Vector2(toggleorigin_position.x, toggleorigin_position.y - 280);

        blurTarget_position = new Vector2(blurorign_position.x, blurorign_position.y - 280);
        if (!showDialmenu)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = Target_position;
            blurBackground.GetComponent<RectTransform>().anchoredPosition = blurTarget_position;
            toggleHandler.GetComponent<RectTransform>().anchoredPosition = toggleTarget_position;

            showDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
            hideDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
            shadowObj.GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
            foreach (var icon in showDialmenuIcons)
            {
                icon.GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
                icon.GetChild(1).GetComponent<TMP_Text>().color = new Color(1, 1, 1, 0);
            }
            donttouchOBJ.SetActive(true);
        }
        else
        {
            hideDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
            showDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
            shadowObj.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);

            foreach (var icon in showDialmenuIcons)
            {
                icon.GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                icon.GetChild(1).GetComponent<TMP_Text>().color = new Color(1, 1, 1, 1);
            }
            donttouchOBJ.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (opacity > 0 && opacity <= 1)
        {
            opacitySpeed *= 1.1f;
        }
        if (!showDialmenu)
        {
            opacitySpeed *= 1.15f;
            if (opacity > 0)
                opacity -= opacitySpeed;
            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(gameObject.GetComponent<RectTransform>().anchoredPosition, Target_position, 0.08f);
            blurBackground.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(blurBackground.GetComponent<RectTransform>().anchoredPosition, blurTarget_position, 0.08f);
            toggleHandler.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(toggleHandler.GetComponent<RectTransform>().anchoredPosition, toggleTarget_position, 0.08f);

            showDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, opacity);
            hideDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, 1 - opacity);

            shadowObj.GetComponent<RawImage>().color = new Color(1, 1, 1, opacity);
            foreach (var icon in showDialmenuIcons)
            {
                icon.GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, opacity);
                icon.GetChild(1).GetComponent<TMP_Text>().color = new Color(1, 1, 1, opacity);
            }
            donttouchOBJ.SetActive(true);


        }
        else
        {
            if (opacity <= 1)
                opacity += opacitySpeed;

            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(gameObject.GetComponent<RectTransform>().anchoredPosition, orign_position, 0.1f);
            blurBackground.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(blurBackground.GetComponent<RectTransform>().anchoredPosition, blurorign_position, 0.1f);
            toggleHandler.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(toggleHandler.GetComponent<RectTransform>().anchoredPosition, toggleorigin_position, 0.1f);

            hideDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, 0 - opacity);
            showDialmenuOBJ.GetComponent<RawImage>().color = new Color(1, 1, 1, opacity);

            shadowObj.GetComponent<RawImage>().color = new Color(1, 1, 1, opacity);
            foreach (var icon in showDialmenuIcons)
            {
                icon.GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, opacity);
                icon.GetChild(1).GetComponent<TMP_Text>().color = new Color(1, 1, 1, opacity);
            }
            donttouchOBJ.SetActive(false);

        }
    }
}
