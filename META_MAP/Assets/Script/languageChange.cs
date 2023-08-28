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
    public static bool firsttime = true;
    string reclick = "null";
    private void Start()
    {
        select = GetComponent<SelectLang>();
        set_UI_background.oneeng = true;
        set_UI_background.onekor = true;
        firsttime = true;
        firstcheck();
        firsttime = false;
    }
    // private void OnEnable()
    // {
    //     Debug.Log("호출2");
    //     set_UI_background.oneeng = true;
    //     set_UI_background.onekor = true;
    //     firstcheck();
    // }
    private void Update()
    {
        //Debug.Log(set_UI_background.oneeng + "   " + set_UI_background.oneeng);
    }
    void firstcheck()
    {
        noUIName = false;

        try
        {
            uIName = GameObject.Find("GameObject").GetComponent<UIName>();
            uIName.changeUI(langsetting);
        }
        catch
        {
            noUIName = true;
        }
        if (firsttime && langsetting == 0)
        {
            uIName = GameObject.Find("GameObject").GetComponent<UIName>();
            onClick_KOR();
            onClick_ENG();
            Debug.Log("시작");
            uIName.changeUI(langsetting);
            firsttime = false;
        }
    }




    public void onClick_ENG()
    {
        if (reclick != "eng")
            StartCoroutine("onclick_ENG");
        reclick = "eng";

    }
    public void onClick_KOR()
    {
        if (reclick != "kor")
            StartCoroutine("onclick_KOR");
        reclick = "kor";
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
        firstcheck();

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
        firstcheck();
    }
}
