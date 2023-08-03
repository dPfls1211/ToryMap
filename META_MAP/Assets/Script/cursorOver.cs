using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cursorOver : MonoBehaviour
{
    MainCamera_Action maincam;
    
    private void Awake() {
        
    }
    // Start is called before the first frame update
    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()==true){
                this.GetComponent<MainCamera_Action>().iscanMove=false;
            }
        }
        if(Input.GetMouseButtonUp(0)){
            this.GetComponent<MainCamera_Action>().iscanMove=true;
        }
        if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()==true) {
            this.GetComponent<MainCamera_Action>().iscanWheel=false;
        }
        else{
            this.GetComponent<MainCamera_Action>().iscanWheel=true;
        }
    }
}
