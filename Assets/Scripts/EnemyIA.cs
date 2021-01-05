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
        GameCTL.Instance.GetGrid().GetTiles()[5,5].SetIsUsed(true);
        GameCTL.Instance.GetGrid().GetTiles()[5,5].InstantiateUnit(Resources.Load("Prefabs/Units/"+1.ToString()) as GameObject,-1);
        GameCTL.Instance.GetGrid().GetTiles()[5,5].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[1],-2);
        GameCTL.Instance.GetGrid().GetTiles()[11,5].SetIsUsed(true);
        GameCTL.Instance.GetGrid().GetTiles()[11,5].InstantiateUnit(Resources.Load("Prefabs/Units/"+1.ToString()) as GameObject,-1);
        GameCTL.Instance.GetGrid().GetTiles()[11,5].GetUnit().AcivingTheUnit(GameCTL.Instance.GetListOfAllCards()[1],-2);
        _random = new System.Random();
        _deck = new List<Card>();
        _hand = new List<Card>();
        GameCTL.Instance.ReadDeck("/deck.txt",_deck);
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DrawCard(){
        if(_hand.Count < 5 && _deck.Count > 0){
            int index = _random.Next(0,_deck.Count);
            _hand.Add(_deck[index]);
            _deck.RemoveAt(index);
        }else{
            Debug.Log("impossible draw,hand full");
        }
    }
}
