using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetmodalContents : MonoBehaviour
{
    public string modalTitle = "교육/회의 관련 정보";
    public GameObject contentsPrefab;
    public int contentsCount;
    public GameObject contentsBox;

    public bool darkmode = false;
    // Start is called before the first frame update
    void Awake()  //나중에 JSON정보 읽어와서 foreach해서 생성되도록.
    {
        for (int i = 0; i < contentsCount; i++)
        {
            Instantiate(contentsPrefab).transform.SetParent(contentsBox.transform);
        }
        if (darkmode)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
