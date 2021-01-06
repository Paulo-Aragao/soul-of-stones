using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Unit
{
    [SerializeField] private GameObject _VfxPrefab;
    private void OnEnable() {
        Invoke("Attacking",1f);
    }
    public void Attacking(){
        RangeTiles tilesInRange = _cardRefence.GetAtkRange();
        Tile currentTile = gameObject.transform.parent.gameObject.GetComponent<Tile>();
        currentTile.SpawnVFX(_VfxPrefab);
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
                    if(targetTile.GetUnit().GetPlayerId() != _playerId){
                        targetTile.GetUnit().TakeDamage(currentTile.GetUnit().GetCardRefecence().GetAtkDamage());  
                    }
                }
            }   
        }
        Die();
    }
}
