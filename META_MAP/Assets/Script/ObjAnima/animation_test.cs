using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_test : MonoBehaviour
{
    Animation ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        ss();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ss()
    {
        ani.Play();
    }
}
