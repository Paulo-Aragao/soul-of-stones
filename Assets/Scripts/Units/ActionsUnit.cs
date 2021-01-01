using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsUnit : MonoBehaviour
{
    //base attack of all unity
    public void Attacking(int playerID,Tile currentTile,RangeTiles tilesInRange){
        foreach (var tile in tilesInRange.GetTileInRange())
        {
            if((int)currentTile.transform.position.z + tile[1] < GameCTL.Instance.GetGrid().GetLines()
                && (int)currentTile.transform.position.z + tile[1] >= 0
                && (int)currentTile.transform.position.x + tile[0] < GameCTL.Instance.GetGrid().GetColumns()
                && (int)currentTile.transform.position.x + tile[0] >= 0)
            {
                Tile targetTile = GameCTL.Instance.GetGrid().GetTiles()[(int)currentTile.transform.position.x + tile[0],
                                                                (int)currentTile.transform.position.z + tile[1]];
                if(playerID != -2){
                    Debug.Log(GameCTL.Instance.GetGrid().GetTiles()[5,5].GetIsUsed());
                }    
                if(targetTile.GetIsUsed()){//&& targetTile.GetUnit().GetUser() != playerID
                    //Debug.Log(playerID+ " attack >>> " + targetTile.GetUnit().GetUser());
                    if(targetTile.GetUnit().GetUser() != playerID){
                        targetTile.GetUnit().TakeDamage(targetTile.GetUnit().GetCardRefecence().GetAtkDamage());
                    }
                };
                targetTile._VFX.SetActive(true);    
            }   
        }
    }
    //base heal move of all healers
    public void Healing(RangeTiles tilesInRange){
        //TODO
    }
}
