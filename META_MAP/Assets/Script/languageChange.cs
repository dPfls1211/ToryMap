using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class languageChange : MonoBehaviour
{
    
    public void onClick_ENG(){
        UserLocalization(0);
    }
    public void onClick_KOR(){
        UserLocalization(1);
    }
    public void UserLocalization(int index) {
    	LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
    
}
