using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _id;
    private Renderer _rend;
    [SerializeField] private Unit _unit;

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
    #endregion
    void Start()
    {
        _rend = GetComponent<Renderer>();
    }
    
    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        if(PlayerCTL.Instance.GetDragingCard()){
            PlayerCTL.Instance.SetTargetTile(this);
            if(_unit.isActiveAndEnabled){
                _rend.material.color = Color.red;
            }else{
                _rend.material.color = Color.blue;
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
