using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICTL : MonoBehaviour
{
    [SerializeField] private Slider _mainTowerLifeBar;

    public Slider GetMainTowerLifeBar(){
        return _mainTowerLifeBar;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
