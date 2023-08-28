
using UnityEngine;

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

}
