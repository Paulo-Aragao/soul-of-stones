using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    void OnMouseDown() 
    {
        PlayerCTL.Instance.GetPanelUnit().GetComponent<UnitPanelGUI>().Active(true,gameObject.transform.parent.gameObject.GetComponent<Unit>());
    }
}
