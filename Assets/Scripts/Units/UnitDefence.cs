using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDefence : Unit
{
    private float timer;
    private float coolDownAtkBase;
    private void OnEnable() {
        timer = 0;
        coolDownAtkBase = _cardRefence.GetAtkSpeed();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > coolDownAtkBase){
            coolDownAtkBase += _cardRefence.GetAtkSpeed();
            _actions.Attacking(_user,transform.parent.gameObject.GetComponent<Tile>(),_cardRefence.GetAtkRange(),
                                Resources.Load("Prefabs/Vfxs/"+_cardRefence.GetAtkVfxId().ToString()) as GameObject);
        }
    }
}
