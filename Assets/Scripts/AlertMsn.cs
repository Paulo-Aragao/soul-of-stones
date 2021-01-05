using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlertMsn : MonoBehaviour
{
    private TextMeshProUGUI _alertText;
    
    
    public TextMeshProUGUI GetAlertText(){
        return _alertText;
    }
    public void SetAlertText(string alertText){
        gameObject.SetActive(false);
        _alertText.text = alertText;
        gameObject.SetActive(true);
    }
    public void Start()
    {
        _alertText = GameObject.FindGameObjectWithTag("alertTxt").GetComponent<TextMeshProUGUI>();
        _alertText.text = "have a good game !";
    }
    public void Disable(){
        gameObject.SetActive(false);
    }
}

