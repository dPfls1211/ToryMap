using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_Type : MonoBehaviour
{
    public enum obj_type
    {
        building,
        video,
        image,
        animation,
        other,
    }

    public obj_type objtype;
}
