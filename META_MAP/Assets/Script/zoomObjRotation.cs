using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomObjRotation : MonoBehaviour
{
    int rotationOne = 0;

    float xmove = 0;
    float ymove = 0;

    bool isturnok = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localEulerAngles = new Vector3(270, 90, 0);
        //gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        //코루틴 한바퀴 돌려주기
        ///StartCoroutine(OneRotation());

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

            // 수정 피벗
            transform.localEulerAngles = new Vector3(-90 - ymove, -xmove, -90);

        }

    }
    void FixedUpdate()
    {
        // if (isturnok)
        // {
        //     BuildingRoatation();
        // }
    }
    IEnumerator OneRotation()
    {


        //gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y * 1, gameObject.transform.rotation.z);

        gameObject.transform.Rotate(Vector3.forward * 1);
        yield return new WaitForSecondsRealtime(0.0000001f);

        if (rotationOne++ > 178)
            yield break;



        yield return OneRotation();

    }
    void BuildingRoatation()
    {
        gameObject.transform.Rotate(Vector3.forward * 1);
        if (rotationOne++ > 178)
            isturnok = false;
    }

}
