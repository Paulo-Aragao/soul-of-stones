using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCTL : MonoBehaviour
{
    private GridCTL _grid;
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
    }
    #endregion
    void Start()
    {
        _grid = GameObject.FindGameObjectWithTag("grid").GetComponent<GridCTL>();
    }

    //execute action card
    public void UserCard(Card card){
        if(PlayerCTL.Instance.GetTargetTile() != null){
            switch (card.GetCardType())
            {
                case "unit":
                    PlayerCTL.Instance.PlantUnit(card);
                    break;
                default:
                    break;
            }
        }
    }
}
