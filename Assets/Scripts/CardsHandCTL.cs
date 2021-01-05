using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardsHandCTL : MonoBehaviour
{
    [SerializeField] private List<CardUI> _cardsSpawners;
    
    
    public bool ExistFreeSpaceCard(){
        foreach (var card in _cardsSpawners)
        {   
            if(!card.isActiveAndEnabled){
                return true;
            }
        }
        return false;
    }
    public void AddCardInHand(Card card){
        for (int i = 0; i < _cardsSpawners.Count; i++)
        {
            if(!_cardsSpawners[i].isActiveAndEnabled){
                _cardsSpawners[i].gameObject.SetActive(true);
                _cardsSpawners[i].SetName(card.GetName());
                _cardsSpawners[i].SetCardId(card.GetId());
                _cardsSpawners[i].SetImageCard(card.GetId());
                _cardsSpawners[i].SetManaCost(card.GetId());
                break;
            }
        }
    }

}
