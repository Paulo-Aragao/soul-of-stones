using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    void OnMouseDown() 
    {
        PlayerCTL.Instance.GetPanelUnit().SetActive(true);
    }
}
