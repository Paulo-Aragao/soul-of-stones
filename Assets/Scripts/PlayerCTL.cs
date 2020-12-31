using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerCTL : MonoBehaviour
{
    private int _id;
    private string _name;
    private int _deckSize = 30;
    private List<Card> _deck;
    private List<Card> _hand;
    private List<Card> _gy;
    private CardsHandCTL _handCTL;
    //acess variables
    private Tile _targetTile;
    //status variables
    private bool _dragingCard;
    #region GETS AND SETS  
    public bool GetDragingCard(){
        return _dragingCard;
    }
    public void SetDragingCard(bool draging){
        _dragingCard = draging;
    }
    public Tile GetTargetTile(){
        return _targetTile;
    }
    public void SetTargetTile(Tile tile){
        _targetTile = tile;
    }
    #endregion 
    #region SINGLETON 
    private static PlayerCTL _instance;
    public static PlayerCTL Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerCTL>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    
    void Start()
    {
        _handCTL = GameObject.FindGameObjectWithTag("handCTL").GetComponent<CardsHandCTL>();
        _deck = new List<Card>();
        _hand = new List<Card>();
        for (int i = 0; i < _deckSize; i++)
        {
            Card card = GameCTL.Instance.PickACardInListOfAllCards(true);
            _deck.Add(new Card(card.GetId(),card.GetName(),card.GetKingdom(),card.GetCardType(),card.GetRespawnCooldown(),
                            card.GetManaCost(),card.GetUnityType(),card.GetHp(),card.GetAtkRange(),card.GetAtkDamage(),
                            card.GetAtkSpeed(),card.GetHealPower(),card.GetHealRange(),card.GetHealSpeed(),card.GetMoveSpeed()));
        } 
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
            
        }
          
    }
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            DrawCard();
        }
    }
    public void DrawCard(){
        if(_handCTL.ExistFreeSpaceCard() && _deck.Count > 0){
            var random = new System.Random();
            int index = random.Next(0,_deck.Count);
            _hand.Add(_deck[index]);
            _handCTL.AddCardInHand(_deck[index]);
            _deck.RemoveAt(index);
        }else{
            Debug.Log("impossible draw,hand full");
        }
    } 

}
