using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Tile : MonoBehaviour
{
    private int _id;
    private Renderer _rend;
    [SerializeField] private Transform _unitPosition;
    [SerializeField] private Unit _unit;
    [SerializeField] private bool _isUsed = false;
    [SerializeField] public Transform _positionVFX;
    
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
    public Transform GetUnitPostion(){
        return _unitPosition;
    }
    #endregion
    void Awake()
    {
        _isUsed = false;
        _rend = GetComponent<Renderer>();
    }
    void Start()
    {
        PlayerCTL.Instance.GetEventChangeColorTiles().AddListener(ChangeColor);
    }
    public void ChangeColor(){
        if(PlayerCTL.Instance.GetDragingCard() && transform.position.x < 5){
            if(_isUsed){
                _rend.material.color = Color.red;
            }else{
                _rend.material.color = Color.green;
            }
        }else{
            _rend.material.color = Color.white;
        }
    }
    public void FreeUnit(){
        _unit = null;
        _isUsed = false;
    }
    public void SpawnVFX(GameObject vfx){
        var vfx_ = vfx;
        vfx_ = Instantiate(vfx, _positionVFX.position, _positionVFX.transform.rotation);
        vfx_.transform.parent = gameObject.transform;
    }
    public void InstantiateUnit(GameObject unit,int playerId){
        var unit_ = unit.GetComponent<Unit>();
        _unit = Instantiate(unit_, _unitPosition.position, _unitPosition.transform.rotation);
        _unit.SetUser(playerId);
        _unit.transform.parent = gameObject.transform;
    }
    public void UpdateUnit(GameObject unit,int playerId){
        var unit_ = unit.GetComponent<Unit>();
        _unit.SetUser(playerId);
        _unit.transform.parent = gameObject.transform;
    }
    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        if(PlayerCTL.Instance.GetDragingCard() && transform.position.x < 5){
            PlayerCTL.Instance.SetTargetTile(this);
        }
    }
    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseOver()
    {
        _rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        if(PlayerCTL.Instance.GetDragingCard()){
            PlayerCTL.Instance.GetEventChangeColorTiles().Invoke();
            if(_isUsed || transform.position.x >= 5){
                _rend.material.color = Color.red;
            }else{
                _rend.material.color = Color.blue;
            }
        }
    }
    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        PlayerCTL.Instance.SetTargetTile(null);
        //_rend.material.color = Color.white;
    }
}
