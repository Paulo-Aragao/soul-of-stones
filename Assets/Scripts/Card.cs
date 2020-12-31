using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
public class Card : MonoBehaviour
{
    [SerializeField] protected int _id;
    [SerializeField] protected string _name;
    [SerializeField] protected string _kingdom;
    [SerializeField] protected string _cardType;//unit, global
    [SerializeField] protected int _manaCost;
    [SerializeField] protected int _respawnCooldown;
    [SerializeField] protected string _sprite;
    [SerializeField] private string _unityType;//tank, hero, range, batedor, desbrador
    [SerializeField] private int _hp;
    [SerializeField] private RangeTiles _atkRange;
    [SerializeField] private int _atkDamage;
    [SerializeField] private int _atkSpeed;
    [SerializeField] private int _healPower;
    [SerializeField] private RangeTiles _healRange;
    [SerializeField] private int _healSpeed;
    [SerializeField] private int _moveSpeed;
    #region GETS AND SETS  
    public int GetId(){
        return _id;
    }
    public void SetId(int id){
        _id = id;
    }
    public string GetName(){
        return _name;
    }
    public void SetName(string name){
        _name = name;
    }
    public string GetKingdom(){
        return _kingdom;
    }
    public void SetKingdom(string kingdom){
        _kingdom = kingdom;
    }
    public string GetCardType(){
        return _cardType;
    }
    public void SetCardType(string cardType){
        _cardType= cardType;
    }
    public int GetHp(){
        return _hp;
    }
    public void SetHp(int hp){
        _hp = hp;
    }
    public int GetManaCost(){
        return _manaCost;
    }
    public void SetManaCost(int manaCost){
        _manaCost = manaCost;
    }
    public int GetRespawnCooldown(){
        return _respawnCooldown;
    }
    public void SetRespawnCooldown(int respawnCooldown){
        _respawnCooldown = respawnCooldown;
    }
    public RangeTiles GetAtkRange(){
        return _atkRange;
    }
    public void SetAtkRange(RangeTiles rangeATK){
        _atkRange = rangeATK;
    }
    public string GetUnityType(){
        return _unityType;
    }
    public void SetUnityType(string unityType){
        _unityType = unityType;
    }
    public int GetAtkDamage(){
        return _atkDamage;
    }
    public void SetAtkDamage(int atkDamage){
        _atkDamage = atkDamage;
    }
    public int GetAtkSpeed(){
        return _atkSpeed;
    }
    public void SetAtkSpeed(int atkSpeed){
        _atkSpeed = atkSpeed;
    }
    public int GetHealPower(){
        return _healPower;
    }
    public void SetHealPower(int healPower){
        _healPower = healPower;
    }
    public RangeTiles GetHealRange(){
        return _healRange;
    }
    public void SetHealPower(RangeTiles healRange){
        _healRange = healRange;
    }
    public int GetHealSpeed(){
        return _healSpeed;
    }
    public void SetHealSpeed(int healSpeed){
        _healSpeed = healSpeed;
    }
    public int GetMoveSpeed(){
        return _moveSpeed;
    }
    public void SetMoveSpeed(int moveSpeed){
        _moveSpeed = moveSpeed;
    }
    #endregion 
    // Start is called before the first frame update
    
    public Card(int id,string name,string kingdom ,string cardType,
                    int respawnCooldown,int manaCost,string unityType,
                    int hp, RangeTiles atkRange,int atkDamage,int atkSpeed,
                    int healPower,RangeTiles healRange,int healSpeed,
                    int moveSpeed){
        _id = id;
        _name = name;
        _kingdom = kingdom;
        _cardType = cardType;
        _respawnCooldown = respawnCooldown;
        _manaCost = manaCost;
        _unityType = unityType;
        _hp = hp;
        _atkRange = atkRange;
        _atkDamage = atkDamage;
        _atkSpeed = atkSpeed;
        _healPower = healPower;
        _healRange = healRange;
        _healSpeed = healSpeed;
        _moveSpeed = moveSpeed;
    }
}
