using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject Target;               // 카메라가 따라다닐 타겟

    public float offsetX = 0.0f;            // 카메라의 x좌표
    public float offsetY = 10.0f;           // 카메라의 y좌표
    public float offsetZ = -10.0f;          // 카메라의 z좌표

    public float cameraRoY = -1.5f;         // 카메라의 Y회전 좌표

    public float CameraSpeed = 5.0f;       // 카메라의 속도
    Vector3 TargetPos;                      // 타겟의 위치

    public float speed = 20.0f;
    Vector3 worldDefalutForward;


    private Camera thisCamera;
    private Vector3 offsetVector;

    private float xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;

    float xmove = 180;
    float ymove = 0;
    float zmove = 0;

    public bool checkedCamReset = true;
    public float distanceRidance = 80;
    public float distanceRidancesValue = 60;

    public bool canvasClickedCheck = false;

    public bool iscanMove = true;
    public bool iscanWheel = true;

    public float zoomMax = 65.0f;
    bool zoominCheckboolean = false;

    GameObject firstObj;
    UIexplain explainCanvas;

    Quaternion rotationQuaternion;
    void Awake()
    {
        //explainCanvas = gameObject.transform.parent.gameObject.GetComponent<UIexplain>();
        setViewTarget.localUIControlCs = gameObject.transform.parent.gameObject.GetComponent<UIexplain>();
        //setViewTarget.myOBJ = GameObject.Find("GameObject");
    }
    void Start()
    {
        checkedCamReset = true;
        thisCamera = gameObject.GetComponent<Camera>();
        worldDefalutForward = transform.forward;

        distanceRidance = distanceRidancesValue;

        offsetVector = new Vector3(offsetX, offsetY, offsetZ);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //보는 방향 계산
        Vector3 dir = Target.transform.position - this.transform.position;
        // dir.y += offsetZ;
        //  float distanceRidance = Vector2.Distance(new Vector2(Target.transform.position.x,Target.transform.position.z),new Vector2(this.transform.position.x+offsetX,this.transform.position.z+offsetZ));

        if (!EventSystem.current.IsPointerOverGameObject() && iscanMove)
        {

            if (!canvasClickedCheck)
            {
                if (Input.GetMouseButton(0))
                {
                    if (checkedCamReset)
                    {
                        xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
                        ymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적합니다.
                        distanceRidance = distanceRidancesValue;
                        if (ymove < -34)
                            ymove = -34;
                        if (ymove > 10)
                            ymove = 10;
                    }
                    else
                    {
                        // //줌인 상태에서 다시 클릭 했을때만,
                        // if (zoominCheckboolean)
                        //     resetZoom();
                        // distanceRidance = 24;
                        // //Debug.Log(distanceRidance);
                        // if (ymove < -1)
                        //     ymove = 5;
                        // if (ymove > 8)
                        //     ymove = 8;
                    }

                    dir = Target.transform.position - this.transform.position;

                    //보는 타겟이 좀 더 위로 올라가도록 임의로 설정
                    rotationQuaternion = Quaternion.LookRotation(dir);


                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (!checkedCamReset)
                    {
                        zoominCheckboolean = true;
                    }
                }
                // if (Input.GetMouseButton(1))
                // {
                //     xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
                //     ymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적합니다.

                //     if (checkedCamReset)
                //     {
                //         distanceRidance = distanceRidancesValue;
                //         if (ymove < -34)
                //             ymove = -34;
                //         if (ymove > 10)
                //             ymove = 10;
                //     }
                //     else
                //     {
                //         distanceRidance = 24;
                //         if (ymove < -1)
                //             ymove = -1;
                //         if (ymove > 8)
                //             ymove = 8;
                //     }
                // }
            }
        }
        else
        {
            //rotationQuaternion = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * CameraSpeed);
        }
        //보는 타겟이 좀 더 위로 올라가도록 임의로 설정
        dir.y += offsetZ;
        if (zoominCheckboolean)
            ymove = 5;
        //회전 함수
        this.transform.rotation = Quaternion.LookRotation(dir);
        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * CameraSpeed * 2);

        var rad = Mathf.Deg2Rad * xmove;
        var x = distanceRidance * Mathf.Sin(rad);
        var z = distanceRidance * Mathf.Cos(rad);

        Quaternion rotationCam = Quaternion.Euler(xmove, 0, 0);
        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3(
            Target.transform.position.x + x,
            Target.transform.position.y + offsetY + ymove,
            Target.transform.position.z + z
            );
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distanceRidance);

        // Vector3 postionCamTarget = TargetPos - transform.rotation ; 


        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

    }

    void Update()
    {
        float usespeed = 0;
        if (!iscanWheel)
            usespeed = 0;
        else
            usespeed = speed;
        float scroll = -Input.GetAxis("Mouse ScrollWheel") * usespeed;

        //최대 줌인
        if (thisCamera.fieldOfView <= 20.0f && scroll < 0 && iscanMove)
        {
            thisCamera.fieldOfView = 20.0f;
        }
        //최대 줌 아웃
        else if (thisCamera.fieldOfView >= zoomMax && scroll > 0 && iscanMove)
        {
            //resetZoom();
        }

        //UI 클릭 체크  if문 추가
        //줌인 아웃 하기

        if (checkedCamReset)
            thisCamera.fieldOfView += scroll;


    }
    public void resetZoom()
    {
        //setViewTarget.localUIControlCs.objON = false;
        //setViewTarget.localUIControlCs.canvasOff();
        firstObj = null;
        thisCamera.fieldOfView = zoomMax;
        //zoomMax = 85f;
        //GameObject.Find("Main Camera").GetComponent<cameraRotation>().TargetViewAsset = GameObject.Find("plane");
        //GameObject.Find("Main Camera").GetComponent<cameraRotation>().ResetView();
        Target = gameObject.transform.parent.gameObject;
        offsetX = offsetVector.x;
        offsetY = offsetVector.y;
        offsetZ = offsetVector.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(worldDefalutForward), 0.015f);
        checkedCamReset = true;
        distanceRidance = distanceRidancesValue;

        //ui 툴킷
        //explaneUI.GetComponent<ExplaneUIController>().hiddenUI();
        //gameObject.transform.parent.gameObject.GetComponent<UIName>().UI_entericon.SetActive(false);
        zoominCheckboolean = false;
    }
}