using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCTL : MonoBehaviour
{
    [SerializeField] private int _columns,_lines;
    [SerializeField] private GameObject _tilePrefab;
    //private List<Tile> _tiles = new List<Tile>();
    private Tile[,] _tiles;

    #region GETS AND SETS
    public int GetColumns(){
        return _columns;
    }  
    public int GetLines(){
        return _lines;
    }
    public Tile[,] GetTiles(){
        return _tiles;
    }
    public void SetTiles(Tile[,] tilesList){
        _tiles = tilesList;
    }
    #endregion 
    // Start is called before the first frame update
    void Start()
    {
        _tiles = new Tile[_columns, _lines];
        transform.position = new Vector3(0,0,0);
        GameObject tile;
        int id = 0;
        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _lines; j++)
            {
                tile = Instantiate(_tilePrefab, new Vector3(i, 0, j), Quaternion.identity);
                tile.transform.parent = gameObject.transform;
                tile.GetComponent<Tile>().SetId(id);
                id++;
                _tiles[i,j] = tile.GetComponent<Tile>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
