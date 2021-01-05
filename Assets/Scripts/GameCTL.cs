using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameCTL : MonoBehaviour
{
    private GridCTL _grid;
    private System.Random _random;
    private AlertMsn _alertMsn;
    //cards de teste
    [SerializeField] private List<Card> _listOfAllCards;
    public List<Card> GetListOfAllCards(){
        return _listOfAllCards;
    }
    public GridCTL GetGrid(){
        return _grid;
    }
    #region SINGLETON
    private static GameCTL _instance;
    public static GameCTL Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameCTL>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _random = new System.Random();
        _grid = GameObject.FindGameObjectWithTag("grid").GetComponent<GridCTL>();
        _listOfAllCards = new List<Card>();
        ReadData("/cards.tsv");  
        _alertMsn = GameObject.FindGameObjectWithTag("alertTxt").GetComponent<AlertMsn>();
    }
    #endregion
    void Start()
    {
    } 
    public Card PickACardInListOfAllCards(bool randomCard, int id = -1){
        if(randomCard){
            int index = _random.Next(_listOfAllCards.Count);
            return _listOfAllCards[index];
        }else{
            try
            {
                int index = _listOfAllCards.FindIndex(c => c.GetId() == id);
                return _listOfAllCards[index];
            }
            catch (System.Exception)
            {
                Debug.LogError("erro acess card ID");
                throw;
            }
            
        }
    }
    //TODO:: CAMINHO Trilha_Data/StreamingAssets/   Assets/Data/
    private void ReadData(string filePath){
        using(var reader = new StreamReader(Application.streamingAssetsPath+filePath))
        {
            //tsv columns
            //0-name	1-kingdom	2-card_type	3-cost_mana	4-unit_type	
            //5-hp	  6-atk_range	  7-atk_damage	8-atk_speed	
            //9-heal_power	 10-heal_range	  11-heal_speed	
            //12-respawn_cooldown	13-move_speed 14-atk_vfx_id
            int countId = 0;
            bool head = true;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('\t');
                if(!head){
                    Card card = new Card(countId,
                                    values[0],
                                    values[1],
                                    values[2],
                                    int.Parse(values[12]),
                                    int.Parse(values[3]),
                                    values[4],
                                    int.Parse(values[5]),
                                    new RangeTiles(values[6]),
                                    int.Parse(values[7]),
                                    int.Parse(values[8]),
                                    int.Parse(values[9]),
                                    new RangeTiles(values[10]),
                                    int.Parse(values[11]),
                                    int.Parse(values[13]),
                                    int.Parse(values[14])); 
                    _listOfAllCards.Add(card);
                    countId++;
                }
                head = false;
            }
        }
    }
    public void ReadDeck(string filePath,List<Card> deck){
        using(var reader = new StreamReader(Application.streamingAssetsPath+filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                foreach (var cardId in values)
                {
                    Card card = GameCTL.Instance.PickACardInListOfAllCards(false,int.Parse(cardId));
                    deck.Add(new Card(card.GetId(),card.GetName(),card.GetKingdom(),card.GetCardType(),card.GetRespawnCooldown(),
                                       card.GetManaCost(),card.GetUnityType(),card.GetHp(),card.GetAtkRange(),card.GetAtkDamage(),
                                       card.GetAtkSpeed(),card.GetHealPower(),card.GetHealRange(),card.GetHealSpeed(),card.GetMoveSpeed(),
                                       card.GetAtkVfxId()));
                }
            }
        }
    }
    //execute action card
    public void UseCard(CardUI card){
        PlayerCTL.Instance.GetEventChangeColorTiles().Invoke();
        if(PlayerCTL.Instance.GetTargetTile() != null){
            if(PlayerCTL.Instance.GetMana() >= _listOfAllCards[card.GetCardId()].GetManaCost()){
                PlayerCTL.Instance.SetMana(PlayerCTL.Instance.GetMana() - _listOfAllCards[card.GetCardId()].GetManaCost());
                switch (_listOfAllCards[card.GetCardId()].GetCardType())
                {
                    case "unity":
                        if(!PlayerCTL.Instance.GetTargetTile().GetIsUsed()){
                            PlayerCTL.Instance.GetTargetTile().SetIsUsed(true);
                            try
                            {
                                PlayerCTL.Instance.GetTargetTile().InstantiateUnit(Resources.Load("Prefabs/Units/"+card.GetCardId()) as GameObject,
                                                                                    PlayerCTL.Instance.GetId());
                            }
                            catch (System.Exception e)
                            {
                                Debug.Log(e);
                                throw;
                            }
                            PlayerCTL.Instance.GetTargetTile().GetUnit().AcivingTheUnit(_listOfAllCards[card.GetCardId()],PlayerCTL.Instance.GetId());
                            card.gameObject.SetActive(false); 
                        }
                        break;
                    default:
                        break;
                }
            }else{
                _alertMsn.SetAlertText("Insufficient mana");
            }
        }else{
                _alertMsn.SetAlertText("Invalid location");
        }
    }
    public void EndGame(int winnerPlayerId){
        if(PlayerCTL.Instance.GetId() != winnerPlayerId){
            Debug.Log("player is winner");
        }else{
            Debug.Log("IA is win");
        }
        
    }
}
