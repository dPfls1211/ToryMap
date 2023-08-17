using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Loading_ani : MonoBehaviour
{
    int index = 0;
    GameObject[] bouncelist;

    Animator bounceAni;
    // Start is called before the first frame update
    void Start()
    {
        GetTopLevelChildrenName(gameObject);
        StartCoroutine("bounce");
    }

    // Update is called once per frame

    private void GetTopLevelChildrenName(GameObject parentObject)  //캔버스 하위객체
    {
        bouncelist = new GameObject[parentObject.transform.childCount];
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            bouncelist[i] = parentObject.transform.GetChild(i).gameObject;
        }
    }

    IEnumerator bounce()
    {
        bounceAni = bouncelist[index % 9].GetComponent<Animator>();
        bounceAni.SetBool("isStart_", true);
        yield return new WaitForSeconds(0.9f);
        bounceAni.SetBool("isStart_", false);
        yield return new WaitForSeconds(0.1f);
        index++;
        yield return StartCoroutine("bounce");

    }
}
