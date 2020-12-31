using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTiles : MonoBehaviour
{
    private List<int[]> _tilesInRange;
    
    //-1,-1;-1,0;-1,+1;0,-1;0,+1;+1,-1;+1,0;+1,+1 exemple of 
    public RangeTiles(string rangeTilesInString){
        _tilesInRange = new List<int[]>();
        var tiles = rangeTilesInString.Split(';');
        for (int i = 0; i < tiles.Length; i++)
        {
            int[] orderedPair = new int[2];
            orderedPair[0] = int.Parse(tiles[i].Split(',')[0]);
            orderedPair[1] = int.Parse(tiles[i].Split(',')[1]);
            _tilesInRange.Add(orderedPair);
        }
    }
}
