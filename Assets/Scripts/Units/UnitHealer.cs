using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealer : Unit
{
    private float timer;
    private float coolDownHealBase;
    private void OnEnable() {
        timer = 0;
        coolDownHealBase = _cardRefence.GetHealSpeed();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > coolDownHealBase){
            coolDownHealBase += _cardRefence.GetHealSpeed();
            _actions.Healing(_playerId,transform.parent.gameObject.GetComponent<Tile>(),_cardRefence.GetHealRange(),
                                Resources.Load("Prefabs/Vfxs/"+_cardRefence.GetAtkVfxId().ToString()) as GameObject);
        }
    }
}
