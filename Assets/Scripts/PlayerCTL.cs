using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCTL : MonoBehaviour
{
    private int _id;
    private string _name;
    private List<Card> _deck;
    private List<Card> _hand;
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
        var random = new System.Random();
        for (int i = 0; i < 0; i++)
        {
            int index = random.Next(_deck.Count);
            _hand.Add(_deck[index]);
        }   
    }
    public void PlantUnit(Card card){
        _targetTile.GetUnit().SetingUnitFromThePLayer(card);
    }

}
