using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBtnLoadScene : MonoBehaviour
{
    public static string LoadScenename = null;
    // Start is called before the first frame update

    public void onClickToURL()
    {
        if (!LoadScenename.Equals(null))
            LoadingSceneManager.LoadScene(LoadScenename);
    }
}
