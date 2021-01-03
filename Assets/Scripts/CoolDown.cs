using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    private float _coolDownTime = 0f;
    private bool _ready = true;
    private float timer = 0f; 
    public CoolDown(float coolDownTime){
        _coolDownTime = coolDownTime;
    }
    public bool IsReady(){
        return _ready;
    }
    public void StartCoolDown(){
        timer = Time.time + _coolDownTime;
        _ready = false;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        if(Time.time > timer){
            
            timer = Time.time + _coolDownTime;
            _ready = true; 
        }
    }
}
