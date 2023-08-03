using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void MoveToLobby()
    {
        SceneManager.LoadScene("LobbyMetaMapScene");
    }

    public void MoveToBuilder()
    {
        SceneManager.LoadScene("BuilderMetaMapSample");
    }
    public void MoveToViewer()
    {
        SceneManager.LoadScene("ViewMetaMapSample");
    }

    public void movetoTest()
    {
        SceneManager.LoadScene("test");
    }
}
