using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _id;
    private Renderer _rend;
    [SerializeField] private Transform _unitPosition;
    [SerializeField] private Unit _unit;
    [SerializeField] private bool _isUsed;
    [SerializeField] public GameObject _VFX;
    #region GETS AND SETS  
    public int GetId(){
        return _id;
    }
    public void SetId(int id){
        _id = id;
    }
    public Unit GetUnit(){
        return _unit;
    }
    public void SetUnit(Unit unit){
        _unit = unit;
    }
    public bool GetIsUsed(){
        return _isUsed;
    }
    public void SetIsUsed(bool isUsed){
        _isUsed = isUsed;
    }
    #endregion
    void Awake()
    {
        _isUsed = false;
        _rend = GetComponent<Renderer>();
    }
    public void InstantiateUnit(GameObject unit,int playerId){
        var unit_ = unit.GetComponent<Unit>();
        _unit = Instantiate(unit_, _unitPosition.position, _unitPosition.transform.rotation);
        _unit.SetUser(playerId);
        _unit.transform.parent = gameObject.transform;
    }
    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        if(PlayerCTL.Instance.GetDragingCard()){
            PlayerCTL.Instance.SetTargetTile(this);
            if(_unit == null){
                _rend.material.color = Color.blue;
            }else{
                _rend.material.color = Color.red;
            }
        }
    }

    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseOver()
    {
        _rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        if(!PlayerCTL.Instance.GetDragingCard()){
            _rend.material.color = Color.white;
        }
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        PlayerCTL.Instance.SetTargetTile(null);
        _rend.material.color = Color.white;
    }
}
