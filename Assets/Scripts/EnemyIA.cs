using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIA : MonoBehaviour
{
    private int _id;
    private int _deckSize = 30;
    private List<Card> _deck;
    private List<Card> _hand;
    private List<Card> _gy;
    private GameObject _panelUnit;
    [SerializeField] private Castle _mainTower;

    private float _coolDownTime = 5f;
    private float timer = 0f; 
    private System.Random _random;

    public Castle GetMainTower(){
        return _mainTower;
    }
    #region SINGLETON 
    private static EnemyIA _instance;
    public static EnemyIA Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemyIA>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        GameCTL.Instance.GetGrid().GetTiles()[13,3].SetIsUsed(true);
        GameCTL.Instance.GetGrid().GetTiles()[13,3].InstantiateUnit(Resources.Load("Prefabs/Units/"+3.ToString()) as GameObject,-1);
        GameCTL.Instance.GetGrid().GetTiles()[13,3].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[3],-1);
        GameCTL.Instance.GetGrid().GetTiles()[12,4].SetIsUsed(true);
        GameCTL.Instance.GetGrid().GetTiles()[12,4].InstantiateUnit(Resources.Load("Prefabs/Units/"+0.ToString()) as GameObject,-1);
        GameCTL.Instance.GetGrid().GetTiles()[12,4].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[0],-1);
        GameCTL.Instance.GetGrid().GetTiles()[12,2].SetIsUsed(true);
        GameCTL.Instance.GetGrid().GetTiles()[12,2].InstantiateUnit(Resources.Load("Prefabs/Units/"+0.ToString()) as GameObject,-1);
        GameCTL.Instance.GetGrid().GetTiles()[12,2].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[0],-1);
        _random = new System.Random();
        _deck = new List<Card>();
        _hand = new List<Card>();
        GameCTL.Instance.ReadDeck("/deck.txt",_deck);
        PlotTowers(11,6,4);
        PlotTowers(11,0,4);
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer){
            timer = Time.time + _coolDownTime;
            int rdColumn = _random.Next(9,14);
            int rdLine = _random.Next(0,6);
            int idCardInDeck = _random.Next(0,_deck.Count);
            if(!GameCTL.Instance.GetGrid().GetTiles()[rdColumn,rdLine].GetIsUsed()){
                GameCTL.Instance.GetGrid().GetTiles()[rdColumn,rdLine].SetIsUsed(true);
                GameCTL.Instance.GetGrid().GetTiles()[rdColumn,rdLine].InstantiateUnit(Resources.Load("Prefabs/Units/"+_deck[idCardInDeck].GetId().ToString()) as GameObject,-1);
                GameCTL.Instance.GetGrid().GetTiles()[rdColumn,rdLine].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[_deck[idCardInDeck].GetId()],-1);
            }
        }
        
    }
    private int Heuristic(){
        int maxHp = 1;
        int sum = 0;
        int selecterLine = 3;
        for (int i = 0; i < GameCTL.Instance.GetGrid().GetLines(); i++)
        {
            if(sum < maxHp){
                maxHp = sum;
                sum = 0;
                selecterLine = i;
            }else{
                sum = 0;
            }
            for (int j = 0; j < GameCTL.Instance.GetGrid().GetColumns(); j++)
            {
                if( GameCTL.Instance.GetGrid().GetTiles()[j,i].GetIsUsed()){
                    if(GameCTL.Instance.GetGrid().GetTiles()[j,i].GetUnit().GetPlayerId() !=-1){
                        sum += GameCTL.Instance.GetGrid().GetTiles()[j,i].GetUnit().GetCardRefecence().GetHp();
                    }
                }
            }
        }
        return selecterLine;
    }
    public void PlotTowers(int x,int y, int cardId){
        GameCTL.Instance.GetGrid().GetTiles()[x,y].SetIsUsed(true);
        GameCTL.Instance.GetGrid().GetTiles()[x,y].InstantiateUnit(Resources.Load("Prefabs/Units/"+cardId.ToString()) as GameObject,-1);
        GameCTL.Instance.GetGrid().GetTiles()[x,y].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[cardId],-1);
    }
    public void DrawCard(){
        if(_hand.Count < 5 && _deck.Count > 0){
            int index = _random.Next(0,_deck.Count);
            _hand.Add(_deck[index]);
        }else{
            Debug.Log("impossible draw,hand full");
        }
    }
}
