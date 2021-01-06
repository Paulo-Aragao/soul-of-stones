using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDefence : Unit
{
    [SerializeField] private bool _isWall;
    private float timer;
    private float coolDownAtkBase = 2f;
    private void OnEnable() {
        timer = 0;
        if(_cardRefence != null){
            coolDownAtkBase = _cardRefence.GetAtkSpeed();
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > coolDownAtkBase && !_isWall){
            coolDownAtkBase += _cardRefence.GetAtkSpeed();
            _actions.Attacking(_playerId,transform.parent.gameObject.GetComponent<Tile>(),_cardRefence.GetAtkRange(),
                                Resources.Load("Prefabs/Vfxs/"+_cardRefence.GetAtkVfxId().ToString()) as GameObject);
        }
    }
    
}
