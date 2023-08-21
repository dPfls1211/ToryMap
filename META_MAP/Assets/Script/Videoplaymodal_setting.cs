using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videoplaymodal_setting : MonoBehaviour
{
    GameObject recodeplay;
    GameObject[] videolist;
    // Start is called before the first frame update
    void Awake()
    {
        recodeplay = GameObject.Find("recodeplay_modal").transform.GetChild(0).transform.gameObject;
        //recodeplay.GetComponent<SetmodalContents>().contentsCount = openModal.recodemodal.GetComponent<SetmodalContents>().contentsCount;
    }
    void Start()
    {


    }
}
