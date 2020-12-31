using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Card _cardRefence;
    private SpriteRenderer _sprite;
    private Animator _anim;
    private int _user;//p1 or p2/IA
    
    public void AcivingTheUnit(Card card){
        _cardRefence = card;
        gameObject.SetActive(true);
    }
}
