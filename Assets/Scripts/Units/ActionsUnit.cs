using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsUnit : MonoBehaviour
{
    //base attack of all unity
    public void Attacking(int playerID,Tile currentTile,RangeTiles tilesInRange,GameObject vfxPrefab = null){
        foreach (var tile in tilesInRange.GetTileInRange())
        {
            if((int)currentTile.transform.position.z + tile[1] < GameCTL.Instance.GetGrid().GetLines()
                && (int)currentTile.transform.position.z + tile[1] >= 0
                && (int)currentTile.transform.position.x + tile[0] < GameCTL.Instance.GetGrid().GetColumns()
                && (int)currentTile.transform.position.x + tile[0] >= 0)
            {
                Tile targetTile = GameCTL.Instance.GetGrid().GetTiles()[(int)currentTile.transform.position.x + tile[0],
                                                                (int)currentTile.transform.position.z + tile[1]];    
                if(targetTile.GetIsUsed()){
                    if(targetTile.GetUnit().GetUser() != playerID){
                        targetTile.GetUnit().TakeDamage(currentTile.GetUnit().GetCardRefecence().GetAtkDamage());
                        if(vfxPrefab != null){
                            targetTile.SpawnVFX(vfxPrefab);
                        }  
                    }
                };
                //use the vfx 
                
            }   
        }
    }
    //base heal move of all healers
    public void Healing(int playerID,Tile currentTile,RangeTiles tilesInRange,GameObject vfxPrefab = null){
        foreach (var tile in tilesInRange.GetTileInRange())
        {
            if((int)currentTile.transform.position.z + tile[1] < GameCTL.Instance.GetGrid().GetLines()
                && (int)currentTile.transform.position.z + tile[1] >= 0
                && (int)currentTile.transform.position.x + tile[0] < GameCTL.Instance.GetGrid().GetColumns()
                && (int)currentTile.transform.position.x + tile[0] >= 0)
            {
                Tile targetTile = GameCTL.Instance.GetGrid().GetTiles()[(int)currentTile.transform.position.x + tile[0],
                                                                (int)currentTile.transform.position.z + tile[1]];    
                if(targetTile.GetIsUsed()){
                    if(targetTile.GetUnit().GetUser() == playerID){
                        targetTile.GetUnit().Heal(currentTile.GetUnit().GetCardRefecence().GetHealPower());
                        if(vfxPrefab != null){
                            currentTile.SpawnVFX(vfxPrefab);
                        }  
                    }
                };
                //use the vfx 
                
            }   
        }
    }
}
