using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakingFerrisWhell : MonoBehaviour
{
    float _rotation=0;
    float _rotaTemp =0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_rotation>3 || _rotation<-3){
            _rotaTemp*=-1;
        }
        _rotation+=_rotaTemp;
        transform.Rotate(new Vector3(0,0,_rotation*Time.deltaTime)) ;
    }
}
