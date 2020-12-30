using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private int _kingdom;
    [SerializeField] private string _cardType;//unity, global
    [SerializeField] private int _hp;
    [SerializeField] private int _rangeATK;
    [SerializeField] private string _unityType;//tank, hero, range, avance
    [SerializeField] private string _sprite;
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
    public string GetCardType(){
        return _cardType;
    }
    public void SetCardType(string cardType){
        _cardType= cardType;
    }
    #endregion 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
