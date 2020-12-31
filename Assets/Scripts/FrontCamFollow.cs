using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCamFollow : MonoBehaviour
{
    private Transform _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.forward);
    }
}
