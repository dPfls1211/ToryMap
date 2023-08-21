using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public GameObject TargetViewAsset; // 부모객체
    public GameObject TargetViewAssets; // 바라볼 플레이어 오브젝트입니다.
    public float xmove = 100;  // X축 누적 이동량 
    public float ymove = 60;  // Y축 누적 이동량
    public float distance = 150;

    public float rotationSpeed = 10;
    public Transform TargetObj;
    public float smoothing = 0.2f;

    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;

    //마우스 클릭 중인지 확인
    bool mouseClicked = true;

    Camera thisCamera;
    Vector3 worldDefalutForward;
    GameObject explaneui_basic;

    Transform ZoomInOutBefore;
    Vector3 reverseDistance;

    Transform tt;
    float lerpTime = 1f;
    float currentTime = 0;
    public bool zoomin = false;

    private void LateUpdate()
    {
        if (zoomin)
        {  //다른 마우스버튼이 클릭중일땐 작동안되게
            Vector3 targetPos = new Vector3(TargetObj.position.x, TargetObj.position.y, this.transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

        }

        //transform.position = Vector3.Lerp(transform.position,new Vector3(trace.position.x,trace.position.y,-10),0.5f*Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        TargetViewAsset = gameObject.transform.parent.gameObject;
        ZoomInOutBefore = TargetViewAsset.transform;
        reverseDistance = new Vector3(0.0f, 0.0f, distance); // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.
        tt = new GameObject().transform;

        thisCamera = gameObject.GetComponent<Camera>();
        worldDefalutForward = transform.forward;
        explaneui_basic = GameObject.Find("ExplaneUICanvas");
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        Rotate();
        if (Input.GetMouseButton(1))
        {
            zoomin = false;
            xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
            ymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적합니다.
            if (ymove < 10)
                ymove = 10;
            if (ymove > 90)
                ymove = 90;
            transform.rotation = Quaternion.Euler(ymove, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정합니다.
            transform.position = TargetViewAsset.transform.position - transform.rotation * reverseDistance; // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.
            ZoomInOutBefore = TargetViewAsset.transform;

        }
        reverseDistance = new Vector3(0.0f, 0.0f, distance); // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.
        transform.position = TargetViewAsset.transform.position - transform.rotation * reverseDistance; // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.
        ZoomInOutBefore = TargetViewAsset.transform;
        if (Input.GetMouseButtonUp(1))
            zoomin = true;
        if (zoomin)
        {
            TargetViewAsset.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

    }


    private void Zoom()
    {
        float scroll = -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        //최대 줌인
        if (thisCamera.fieldOfView <= 20.0f && scroll < 0)
        {
            thisCamera.fieldOfView = 20.0f;
        }
        //최대 줌 아웃
        else if (thisCamera.fieldOfView >= 65.0f && scroll > 0)
        {
            thisCamera.fieldOfView = 65.0f;
            //GameObject.Find("Main Camera").GetComponent<cameraRotation>().TargetViewAsset = GameObject.Find("plane");
            ResetView();
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(worldDefalutForward), 0.015f);
            //explaneui_basic.GetComponent<childcheck>().ExplaneUICanvas.SetActive(false);

            //ui 툴킷
            //explaneUI.GetComponent<ExplaneUIController>().hiddenUI();

        }
        //줌인 아웃 하기
        thisCamera.fieldOfView += scroll;
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rot = transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
            rot.y += Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X 위치 * 회전 스피드
            rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // 마우스 Y 위치 * 회전 스피드
            Quaternion q = Quaternion.Euler(rot); // Quaternion으로 변환
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
        }
    }


    public void MoveCam()
    {
        ///distance = 10;
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정합니다.
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance); // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.
        transform.position = TargetViewAsset.transform.position - transform.rotation * reverseDistance; // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.
    }
    public void MoveCamlerp()
    {
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); // 이동량에 따라 카메라의 바라보는 방향을 조정합니다.
        Vector3 reverseDistance = new Vector3(TargetViewAsset.transform.position.x, TargetViewAsset.transform.position.y, distance); // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.
        ///transform.position = TargetViewAsset.transform.position - transform.rotation * reverseDistance; // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.

        tt.position = TargetViewAsset.transform.position - transform.rotation * reverseDistance;

        //transform.position = Vector3.Lerp(ZoomInOutBefore.position, tt.position, Time.deltaTime * 12f); // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.


        StartCoroutine(MoveToAsset(ZoomInOutBefore, tt));
        currentTime = 0;
        ZoomInOutBefore = TargetViewAsset.transform;

    }

    IEnumerator MoveToAsset(Transform startPosition, Transform endPosition)
    {
        currentTime += 0.02f;
        if (currentTime >= lerpTime)
        {
            currentTime = lerpTime;
            zoomin = true;
            yield break;
        }
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, currentTime); // 플레이어의 위치에서 카메라가 바라보는 방향에 벡터값을 적용한 상대 좌표를 차감합니다.
        //
        Debug.Log(0);
        yield return StartCoroutine(MoveToAsset(startPosition, endPosition));

    }
    public void ResetView()
    {
        zoomin = false;
        setViewTarget.zoomCheck = false;
        StartCoroutine(ResetViewCam());

    }
    IEnumerator ResetViewCam()
    {
        if (distance > 100)
        {
            //   TargetViewAsset = GameObject.Find("Main Camera");
            TargetViewAsset.transform.position = GameObject.Find("plane_map").transform.position;

            yield break;
        }
        yield return new WaitForSeconds(0.05f);
        //Debug.Log(0);
        distance *= 1.1f;
        // Debug.Log(targetViewSC.distance);
        StartCoroutine(ResetViewCam());
    }
}
