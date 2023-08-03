using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class makefile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (false == File.Exists( Application.persistentDataPath+ "PthfileName" +".json"))
            {
                var file = File.CreateText(Application.persistentDataPath+"PthfileName"  + ".json"); 
                file.Close();
            }

        StreamWriter sw = new StreamWriter(Application.persistentDataPath+"PthfileName"  + ".json");

        sw.WriteLine("test");
        sw.Flush();
        sw.Close();
//        Debug.Log(1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
