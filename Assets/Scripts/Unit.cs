using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int _cardId;
    private int _hp;
    private int _rangeATK;
    private string _unityType;//tank, hero, range, avance
    private SpriteRenderer _sprite;
    private Animator _anim;
    private int _user;//p1 or p2/IA
    public Unit(int cardId,int hp, int rangeATK, string unityType){

    }
    public void SetingUnitFromThePLayer(Card card){
        gameObject.SetActive(true);
    }
}
