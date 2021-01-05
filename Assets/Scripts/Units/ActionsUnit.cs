using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsUnit : MonoBehaviour
{
    //base attack main tower/castle
    public void AttackingTheMainTower(int playerID,Tile currentTile,GameObject vfxPrefab = null){
        if(playerID != PlayerCTL.Instance.GetId()){
            PlayerCTL.Instance.GetMainTower().TakeDamage(currentTile.GetUnit().GetCardRefecence().GetAtkDamage());
        }else{
            EnemyIA.Instance.GetMainTower().TakeDamage(currentTile.GetUnit().GetCardRefecence().GetAtkDamage());
        }
    } 
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
                }
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
                    if(targetTile.GetUnit().GetUser() == playerID &&
                      (targetTile.GetUnit().GetCardRefecence().GetUnityType() != "wall" && 
                      targetTile.GetUnit().GetCardRefecence().GetUnityType() != "healer" &&
                      targetTile.GetUnit().GetCardRefecence().GetUnityType() != "tower")
                      ){
                        targetTile.GetUnit().Heal(currentTile.GetUnit().GetCardRefecence().GetHealPower());
                        if(vfxPrefab != null){
                            currentTile.SpawnVFX(vfxPrefab);
                        }  
                    }
                }
            }   
        }
    }
}
