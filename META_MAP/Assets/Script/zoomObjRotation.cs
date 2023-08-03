using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomObjRotation : MonoBehaviour
{
    int rotationOne = 0;

    float xmove = 0;
    float ymove = 0;
    // Start is called before the first frame update
    void Start()
    {
        //코루틴 한바퀴 돌려주기
        StartCoroutine(OneRotation());
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
            ymove -= Input.GetAxis("Mouse Y");// 마우스의 상하 이동량을 ymove 에 누적합니다.
            if (ymove < -10)
                ymove = -10;
            if (ymove > 10)
                ymove = 10;

            transform.eulerAngles = new Vector3(-ymove, -xmove, 0);

        }
    }

    IEnumerator OneRotation()
    {
        gameObject.transform.Rotate(Vector3.up * 1);
        yield return new WaitForSeconds(0.0005f);
        if (rotationOne++ > 358)
            yield break;
        yield return OneRotation();

    }

}
