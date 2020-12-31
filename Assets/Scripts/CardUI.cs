using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardUI : MonoBehaviour
{
    [SerializeField] private int _cardId;
    [SerializeField] private string _name;
    [SerializeField] private Image _imageCard;
    public int GetCardId(){
        return _cardId;
    }
    public void SetCardId(int cardId){
        _cardId = cardId;
    }
    public string GetName(){
        return _name;
    }
    public void SetName(string name){
        _name = name;
    }
    public void SetImageCard(int cardId){
        try
        {
            _imageCard.sprite = Resources.Load<Sprite>("cardsUI/" + cardId); 
        }
        catch (System.Exception e)
        {   
            Debug.LogError(e + " >> " + cardId);
            throw;
        }
        
    }
}
