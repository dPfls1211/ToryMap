
using UnityEngine;

public class DontDestioryObj : MonoBehaviour
{
    public SceneLoader loadsceneOBJ;
    public GameObject blurdialBack;
    public static DontDestioryObj instance;

    public Texture image_mainBackground;

    [SerializeField]
    public bool touch_check = true;
    public static bool touchCheck = true; //true면 touch스크린

    public GameObject camera_main;

    private void Awake()
    {
        touchCheck = touch_check;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
