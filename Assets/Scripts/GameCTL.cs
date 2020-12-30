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
}
