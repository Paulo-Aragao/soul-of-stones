using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] private int _hp = 500;
    [SerializeField] private Slider _lifeBar;
    [SerializeField] private bool _isPlayer = false;
    [SerializeField] private int _damage = 1;
    [SerializeField] private GameObject _spearPrefab;
    private int _userId = -1;
     private float timer;
    private float coolDownAtkBase = 2f;
    void Start()
    {
        _lifeBar.maxValue = _hp;
        _lifeBar.value = _hp;
        if(_isPlayer){  
            _userId = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCTL>().GetId();
        }
    }
    private void Update() {
        timer += Time.deltaTime;
        if(timer > coolDownAtkBase){
            coolDownAtkBase += 1f;
            AttackingUnitsSiege();
        }
    }
    public void AttackingUnitsSiege(){
        if(_isPlayer){
            for (int i = 0; i < 7; i++)
            {
                Tile targetTile = GameCTL.Instance.GetGrid().GetTiles()[0,i]; 
                if(targetTile.GetIsUsed() ){
                    if(targetTile.GetUnit().GetPlayerId() != PlayerCTL.Instance.GetId()){
                        Instantiate(_spearPrefab, targetTile.transform.position, new Quaternion(targetTile.transform.rotation.x,
                                                                                            180,
                                                                                            targetTile.transform.rotation.z,1) );
                        targetTile.GetUnit().TakeDamage(_damage); 
                    }
                } 
            }  
        }else{
            for (int i = 0; i < 7; i++)
            {
                Tile targetTile = GameCTL.Instance.GetGrid().GetTiles()[GameCTL.Instance.GetGrid().GetColumns()-1,i]; 
                if(targetTile.GetIsUsed()){
                    if(targetTile.GetUnit().GetPlayerId() == PlayerCTL.Instance.GetId()){
                        Instantiate(_spearPrefab, targetTile.transform.position, targetTile.transform.rotation);
                        targetTile.GetUnit().TakeDamage(_damage); 
                    }
                } 
            } 
        }
        
    }
    public int GetHp(){
        return _hp;
    }
    public void SetHp(int hp){
        _hp = hp;
    }
    public void TakeDamage(int dmg){
        _hp -= dmg;
        _lifeBar.value = _hp;
        if(_hp < 1){
            GameCTL.Instance.EndGame(_userId);
        }
    }
}
