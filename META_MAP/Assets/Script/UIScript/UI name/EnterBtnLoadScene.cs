using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBtnLoadScene : MonoBehaviour
{
    public static string LoadScenename = null;
    public static float angle = 0;
    // Start is called before the first frame update
    public void onClickToURL()
    {

        //UI 시에서 클릭 시 다이얼 회전.
        dialActiveAni.rotationAngle = angle;

        if (!LoadScenename.Equals(null))
            LoadingSceneManager.LoadScene(LoadScenename);


        //UI 시에서 클릭 시 다이얼 회전.
        //dialActiveAni.rotationAngle 

    }
}
