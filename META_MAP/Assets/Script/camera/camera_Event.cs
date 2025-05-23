using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class camera_Event : MonoBehaviour
{
    //모바일 터치 사용시, true ,, 마우스 클릭 사용시 false
    public bool TouchCheck = false;
    public float scrollSpeed = 20;
    public GameObject TargetObject;
    public GameObject originCam;

    //다른 이벤트와 충돌 나지 않게하는 변수 (UI위에서도 줌인되는 거 막기, 등)
    public bool canvasClickedCheck = false;
    public bool checkedCamReset = true;
    public bool iscanMove = true;
    bool zoominCheckboolean = false;

    // 마우스 값에 따라 카메라 회전
    float xmove = 0;
    float ymove = 0;
    float zmove = 0;
    float cxmove = 0;
    float cymove = 0;
    float czmove = 0;
    public float CameraSpeed = 5.0f;       // 카메라의 속도
    Transform basicObject_set;
    Vector3 basicObject_Position;
    Vector3 basicObject_Rotation;

    float Timedelta = 0;

    Vector2?[] touchPrevPos = { null, null };
    Vector2 touchPrevVector;
    float touchPrevDist;
    Camera camera;

    public float perspectiveZoomSpeed = 0.5f;  //줌인,줌아웃할때 속도(perspective모드 용)      
    public float orthoZoomSpeed = 0.5f;      //줌인,줌아웃할때 속도(OrthoGraphic모드 용) 

    Vector3 FirstPoint;
    Vector3 SecondPoint;
    public float xAngle = 0f;
    public float yAngle = 55f;
    float xAngleTemp;
    float yAngleTemp;

    private void Awake()
    {

        DontDestioryObj.instance.camera_main = GameObject.Find("Main Camera");

        GameObject.Find("blur-dial").GetComponent<Canvas>().worldCamera = gameObject.GetComponent<Camera>();
    }
    private void Start()
    {
        TargetObject = gameObject.transform.parent.gameObject;
        basicObject_set = gameObject.transform;

        //basic
        basicObject_Position.x = -15.9f;
        basicObject_Position.y = 8.39f;
        basicObject_Position.z = 0.81f;
        basicObject_Rotation.x = 26.477f;
        basicObject_Rotation.y = 90;
        basicObject_Rotation.z = 0;


        Screen.orientation = ScreenOrientation.Portrait;
        camera = gameObject.GetComponent<Camera>();

        TouchCheck = DontDestioryObj.instance.touch_check;
    }
    private void Update()
    {
        if (TouchCheck)
            mapTouch();
        else
            roationMapArround();

        // #if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR

        //                 mapTouch();
        // #else
        //             roationMapArround();
        // #endif

    }

    private void LateUpdate()
    {

    }
    private Vector2 nowPos, prePos;
    private Vector2 movePosDiff;
    void mapTouch()
    {
        if (!canvasClickedCheck)
        {

            //터치가 한개일때
            if (Input.touchCount == 1)
            {
                if (checkedCamReset)
                {

                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        prePos = touch.position - touch.deltaPosition;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        nowPos = touch.position - touch.deltaPosition;
                        movePosDiff = (Vector2)(prePos - nowPos) * Time.deltaTime;
                        prePos = touch.position - touch.deltaPosition;
                    }


                    xmove += movePosDiff.x;
                    ymove += movePosDiff.y;

                    if (ymove < -10)
                        ymove = -10;
                    if (ymove > 15)
                        ymove = 15;
                    if (xmove < -20)
                        xmove = -20;
                    if (xmove > 20)
                        xmove = 20;

                    originCam.transform.parent.rotation = Quaternion.Euler(TargetObject.transform.rotation.x, TargetObject.transform.rotation.y - xmove, TargetObject.transform.rotation.z - ymove);
                    //TargetObject.transform.rotation = Quaternion.Euler(TargetObject.transform.rotation.x, TargetObject.transform.rotation.y + xmove + 180, TargetObject.transform.rotation.z - ymove);


                }
            }
            //터치 두개
            else if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0); //첫번째 손가락 터치를 저장
                Touch touchOne = Input.GetTouch(1); //두번째 손가락 터치를 저장

                //터치에 대한 이전 위치값을 각각 저장함
                //처음 터치한 위치(touchZero.position)에서 이전 프레임에서의 터치 위치와 이번 프로임에서 터치 위치의 차이를 뺌
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; //deltaPosition는 이동방향 추적할 때 사용
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // 각 프레임에서 터치 사이의 벡터 거리 구함
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; //magnitude는 두 점간의 거리 비교(벡터)
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                // 거리 차이 구함(거리가 이전보다 크면(마이너스가 나오면)손가락을 벌린 상태_줌인 상태)
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                // 만약 카메라가 OrthoGraphic모드 라면
                if (camera.orthographic)
                {
                    camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
                    camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
                }
                else
                {
                    camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
                    camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
                    if (camera.fieldOfView < 7)
                        camera.fieldOfView = 7;
                    if (camera.fieldOfView > 20)
                        camera.fieldOfView = 20;
                }

            }
            if (!checkedCamReset)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetObject.transform.GetChild(0).rotation, CameraSpeed);
                transform.parent.position = Vector3.Lerp(transform.parent.position, TargetObject.transform.position, CameraSpeed);
                transform.position = Vector3.Lerp(transform.position, TargetObject.transform.GetChild(0).position, CameraSpeed);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originCam.transform.rotation, CameraSpeed);
                transform.position = Vector3.Lerp(transform.position, originCam.transform.position, CameraSpeed);
            }

            if (Input.touchCount == 0)
            {
                touchPrevPos[0] = null;
                touchPrevPos[1] = null;
                zoominCheckboolean = true;
                movePosDiff = Vector3.zero;
            }
        }
    }

    void roationMapArround()
    {
        if (!canvasClickedCheck)
        {
            if (Input.GetMouseButton(0))
            {
                if (checkedCamReset)
                {
                    cxmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
                    cymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적합니다.


                    if (cymove < -10)
                        cymove = -10;
                    if (cymove > 15)
                        cymove = 15;
                    if (cxmove < -20)
                        cxmove = -20;
                    if (cxmove > 20)
                        cxmove = 20;

                    originCam.transform.parent.rotation = Quaternion.Euler(TargetObject.transform.rotation.x, TargetObject.transform.rotation.y + cxmove, TargetObject.transform.rotation.z - cymove);
                    //TargetObject.transform.rotation = Quaternion.Euler(TargetObject.transform.rotation.x, TargetObject.transform.rotation.y + xmove + 180, TargetObject.transform.rotation.z - ymove);


                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                if (!checkedCamReset)
                {
                    zoominCheckboolean = true;
                }
            }


            if (!checkedCamReset)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetObject.transform.GetChild(0).rotation, CameraSpeed);
                transform.parent.position = Vector3.Lerp(transform.parent.position, TargetObject.transform.position, CameraSpeed);
                transform.position = Vector3.Lerp(transform.position, TargetObject.transform.GetChild(0).position, CameraSpeed);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originCam.transform.rotation, CameraSpeed);
                transform.position = Vector3.Lerp(transform.position, originCam.transform.position, CameraSpeed);
            }
            float scroll = -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

            //UI 클릭 체크  if문 추가
            //줌인 아웃 하기

            camera.fieldOfView += scroll;

            if (camera.fieldOfView < 7)
                camera.fieldOfView = 7;
            if (camera.fieldOfView > 20)
                camera.fieldOfView = 20;
        }
    }


    public void OnDrag(Vector2 a_SecondPoint)
    {
        Debug.Log("drag");
        SecondPoint = a_SecondPoint;
        xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
        yAngle = yAngleTemp - (SecondPoint.y - FirstPoint.y) * 90 * 3f / Screen.height; // Y값 변화가 좀 느려서 3배 곱해줌.

        // 회전값을 40~85로 제한
        if (yAngle < 40f)
            yAngle = 40f;
        if (yAngle > 85f)
            yAngle = 85f;

        //originCam.transform.parent.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
        originCam.transform.parent.rotation = Quaternion.Euler(TargetObject.transform.rotation.x, TargetObject.transform.rotation.y + yAngle * CameraSpeed + 180, TargetObject.transform.rotation.z - xAngle * CameraSpeed);

    }
    public void resetZoom()
    {
        gameObject.GetComponent<Camera>().fieldOfView = 12;
        gameObject.GetComponent<Camera>().nearClipPlane = 10;
        gameObject.GetComponent<Camera>().farClipPlane = 1000;

        TargetObject = gameObject.transform.parent.gameObject;
        checkedCamReset = true;

        //ui 툴킷
        //explaneUI.GetComponent<ExplaneUIController>().hiddenUI();
        //gameObject.transform.parent.gameObject.GetComponent<UIName>().UI_entericon.SetActive(false);

        zoominCheckboolean = false;


        TargetObject.transform.rotation = Quaternion.Euler(0, 0, 0);


    }
}
