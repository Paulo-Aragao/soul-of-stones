using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    private Card _cardRefence;
    private ActionsUnit _actions;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _anim;
    [SerializeField] private Slider _lifeBar;
    
    private float _hpPorPercent;//quanto hp equivale a 1% da lifebar
    private int _currentHp;
    private int _user;//p1 or p2/IA
    
    public int GetUser(){
        return _user;
    }
    public void SetUser(int playerId){
        _user = playerId;
    }
    public Card GetCardRefecence(){
        return _cardRefence;
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
    float timer = 0;
    float destiny = 2F;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > destiny){
            destiny +=2F;
            _actions.Attacking(_user,transform.parent.gameObject.GetComponent<Tile>(),_cardRefence.GetAtkRange());
        }
    }
    private IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(5); //code pauses for 5 seconds
        Debug.Log("atk");
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
        transform.parent.gameObject.GetComponent<Tile>().SetIsUsed(false);
        //anim die
        //after drestroy the unity and unset the reference in the tile
        Destroy(gameObject);
    }
    public void Heal(int heal){
        if((_currentHp + heal) > _cardRefence.GetHp()){
            _lifeBar.value = 100;
            //anim heal null
        }
    }
    
}
