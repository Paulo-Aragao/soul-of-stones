using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class PlayerCTL : MonoBehaviour
{
    private int _id;
    private string _name;
    [SerializeField] private int _mana = 10;
    [SerializeField] private int _deckSize = 30;
    private List<Card> _deck;
    private List<Card> _hand;
    private List<Card> _gy;
    private CardsHandCTL _handCTL;
    private System.Random _random;
    private GameObject _panelUnit;
    private UnityEvent _eventChangeColorTiles;
    [SerializeField] private Castle _mainTower;
    [SerializeField]private Slider _manaBar;
    //acess variables
    private Tile _targetTile;
    //status variables
    private bool _dragingCard;
    #region GETS AND SETS 
    public int GetId(){
        return _id;
    } 
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
    public GameObject GetPanelUnit(){
        return _panelUnit;
    }
    public Castle GetMainTower(){
        return _mainTower;
    }
    public UnityEvent GetEventChangeColorTiles(){
        return _eventChangeColorTiles;
    }
    public int GetMana(){
        return _mana;
    }
    public void SetMana(int mana){
        _mana = mana;
        _manaBar.value = 10 - mana;
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
        _eventChangeColorTiles = new UnityEvent();
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    
    void Start()
    {
        SetMana(_mana);
        _random = new System.Random();
        _id = _random.Next(9999999);
        _handCTL = GameObject.FindGameObjectWithTag("handCTL").GetComponent<CardsHandCTL>();
        _panelUnit = GameObject.FindGameObjectWithTag("panelUnit");
        _panelUnit.SetActive(false);
        _deck = new List<Card>();
        _hand = new List<Card>();
        GameCTL.Instance.ReadDeck("/deck.txt",_deck);
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
        PlotTowers(2,6,4);
        PlotTowers(2,6,4);
        PlotTowers(2,0,4);
        PlotTowers(2,0,4);
    }
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            DrawCard();
        }
    }
    public void PlotTowers(int x,int y, int cardId){
        GameCTL.Instance.GetGrid().GetTiles()[x,y].SetIsUsed(true);
        GameCTL.Instance.GetGrid().GetTiles()[x,y].InstantiateUnit(Resources.Load("Prefabs/Units/"+cardId.ToString()) as GameObject,_id);
        GameCTL.Instance.GetGrid().GetTiles()[x,y].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[cardId],_id);
    }
    public void DrawCard(){
        if(_handCTL.ExistFreeSpaceCard() && _deck.Count > 0){
            int index = _random.Next(0,_deck.Count);
            _hand.Add(_deck[index]);
            _handCTL.AddCardInHand(_deck[index]);
            _deck.RemoveAt(index);
        }else{
            Debug.Log("impossible draw,hand full");
        }
    } 
    
}
