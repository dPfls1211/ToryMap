
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class DontDestioryObj : MonoBehaviour
{
    public SceneLoader loadsceneOBJ;
    public static DontDestioryObj instance;

    public Texture image_mainBackground;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public void UserLocalization(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }


}
