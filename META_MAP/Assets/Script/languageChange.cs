using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System;

public class languageChange : MonoBehaviour
{
    public static int langsetting = 1;
    UIName uIName;
    SelectLang select;
    bool noUIName = false;
    private void Awake()
    {
        Debug.Log("호출");
        select = GetComponent<SelectLang>();
        firstcheck();
        onClick_KOR();
    }
    private void OnEnable()
    {
        set_UI_background.oneeng = true;
        set_UI_background.onekor = true;
        firstcheck();
    }
    void firstcheck()
    {
        noUIName = false;
        try
        {
            uIName = GameObject.Find("GameObject").GetComponent<UIName>();
        }
        catch
        {
            noUIName = true;
        }
        Debug.Log(noUIName);
    }




    public void onClick_ENG()
    {
        StartCoroutine("onclick_ENG");

    }
    public void onClick_KOR()
    {
        StartCoroutine("onclick_KOR");
    }

    public void UserLocalization(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];


    }

    IEnumerator onclick_ENG()
    {
        langsetting = 0;
        UserLocalization(0);
        if (set_UI_background.oneeng)
        {
            yield return new WaitForSeconds(0.2f);
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
        }
        if (!noUIName)
        {
            uIName.changeUI(0);
        }

    }

    IEnumerator onclick_KOR()
    {
        langsetting = 1;
        UserLocalization(1);
        if (set_UI_background.onekor)
        {
            yield return new WaitForSeconds(0.2f);
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
        }
        if (!noUIName)
        {
            uIName.changeUI(1);
        }
    }
}
