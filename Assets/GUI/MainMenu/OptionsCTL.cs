using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsCTL : MonoBehaviour
{
    [SerializeField] private Button _BT_moreResolution;
    [SerializeField] private Button _BT_lessResolution;
    [SerializeField] private TMP_Text _resolution;
    [SerializeField] private Button _BT_moreVolume;
    [SerializeField] private Button _BT_lessVolume;
    [SerializeField] private Toggle _TG_fullScreen;
    [SerializeField] private Button _BT_apply;
    [SerializeField] private List<Resolution> _supportedResolutions;

    [System.Serializable]
    public struct Resolution
    {
        public int x;
        public int y;
    }
    
    private int currentResolutionId = 0;
    // Start is called before the first frame update
    void Start()
    {
        //buttom
        _BT_apply.onClick.AddListener(ApplyResolution);
        _BT_moreResolution.onClick.AddListener(ChangeResoltuionNext);
        _BT_lessResolution.onClick.AddListener(ChangeResoltuionPrev);
        _resolution.text = Screen.width.ToString() + "x" + Screen.height.ToString() +"px";
        currentResolutionId = _supportedResolutions.FindIndex(Resolution => Resolution.x == Screen.width);
        if(currentResolutionId == _supportedResolutions.Count-1){
            _BT_moreResolution.gameObject.SetActive(false);
            _BT_lessResolution.gameObject.SetActive(true);
        }else{
            _BT_moreResolution.gameObject.SetActive(true);
            _BT_lessResolution.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ChangeResoltuionNext(){
        currentResolutionId++;
        if(currentResolutionId == _supportedResolutions.Count-1){
            _BT_moreResolution.gameObject.SetActive(false);
            _BT_lessResolution.gameObject.SetActive(true);
        }else{
            _BT_moreResolution.gameObject.SetActive(true);
            _BT_lessResolution.gameObject.SetActive(true);
        }
        _resolution.text = _supportedResolutions[currentResolutionId].x.ToString() + "x" 
                            + _supportedResolutions[currentResolutionId].y.ToString() +"px";
        
    }
    private void ChangeResoltuionPrev(){
        currentResolutionId--;
        if(currentResolutionId == 0){
            _BT_moreResolution.gameObject.SetActive(true);
            _BT_lessResolution.gameObject.SetActive(false);
        }else{
            _BT_moreResolution.gameObject.SetActive(true);
            _BT_lessResolution.gameObject.SetActive(true);
        }
        _resolution.text = _supportedResolutions[currentResolutionId].x.ToString() + "x" 
                            + _supportedResolutions[currentResolutionId].y.ToString() +"px";
    }
    private void ApplyResolution(){
        Screen.SetResolution(_supportedResolutions[currentResolutionId].x,
                             _supportedResolutions[currentResolutionId].y, _TG_fullScreen.isOn);
    }
}
