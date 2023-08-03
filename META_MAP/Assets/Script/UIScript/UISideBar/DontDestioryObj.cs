
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
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

}
