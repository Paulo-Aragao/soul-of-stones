using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICTL : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cardInfo;

    public TextMeshProUGUI GetCardInfo(){
        return _cardInfo;
    }
    public void SetCardInfo(string cardInfos){
        _cardInfo.text = cardInfos;
    }
    #region SINGLETON 
    private static UICTL _instance;
    public static UICTL Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UICTL>();
            }
            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        
    }
}
