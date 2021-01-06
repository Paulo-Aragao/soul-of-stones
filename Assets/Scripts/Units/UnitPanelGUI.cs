using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UnitPanelGUI : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private Image _unitImage;
    [SerializeField] private Image _borders;
    [SerializeField] private Button _remove;
    [SerializeField] private TextMeshProUGUI _description;
    private Unit unit;
    public void Active(bool status,Unit unitReference){
        unit = unitReference;
        gameObject.SetActive(status);
        _description.text = unit.GetCardRefecence().GetName();
        _unitImage.sprite = Resources.Load<Sprite>("Chars/" + unit.GetCardRefecence().GetId());
         
    }
    public void Remove(){
        unit.Die();
        gameObject.SetActive(false);
        PlayerCTL.Instance.SetMana(PlayerCTL.Instance.GetMana() + 1);
    }
    private void OnEnable() {
        
    }
    
}
