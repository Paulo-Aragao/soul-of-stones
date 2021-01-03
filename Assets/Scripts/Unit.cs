using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    protected Card _cardRefence;
    protected ActionsUnit _actions;
    [SerializeField] protected SpriteRenderer _sprite;
    [SerializeField] protected Animator _anim;
    [SerializeField] protected Slider _lifeBar;
    protected float _hpPorPercent;//quanto hp equivale a 1% da lifebar
    protected int _currentHp;
    protected int _user;//p1 or p2/IA
    
    public int GetUser(){
        return _user;
    }
    public void SetUser(int playerId){
        _user = playerId;
    }
    public Card GetCardRefecence(){
        return _cardRefence;
    }
    public SpriteRenderer GetSprite(){
        return _sprite;
    }
    public void AcivingTheUnit(Card card,int userId){
        _user = userId;
        _cardRefence = card;
        gameObject.SetActive(true);
        //TODO: anim de inicio e efeito especial
        _currentHp = _cardRefence.GetHp();
        _hpPorPercent = _currentHp/100f;
    }
    void Start()
    {
        _actions = new ActionsUnit();
        //_actions.Attacking(_user,transform.parent.gameObject.GetComponent<Tile>(),_cardRefence.GetAtkRange());
    }
    public void TakeDamage(int damage){
        if((_currentHp - damage) < 1){
            _lifeBar.value = 0;
            Die();
        }else{
            _currentHp -= damage;
            _lifeBar.value = (int)_currentHp/_hpPorPercent;
        }
    }
    public void Die(){
        transform.parent.gameObject.GetComponent<Tile>().FreeUnit();
        transform.parent.gameObject.GetComponent<Tile>().SetIsUsed(false);
        //anim die
        //after drestroy the unity and unset the reference in the tile
        Destroy(gameObject);
    }
    public void Heal(int heal){
        if((_currentHp + heal) > _cardRefence.GetHp()){
            _lifeBar.value = 100;
            //anim heal null
        }else{
            _currentHp += heal;
            _lifeBar.value = (int)_currentHp/_hpPorPercent;
        }
    }
}
