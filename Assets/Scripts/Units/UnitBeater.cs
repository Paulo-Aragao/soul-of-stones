using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBeater : Unit
{
    private bool _isMoving = false;
    private bool _isInCombat = false;
    private bool _isInCombatWithTheCastle = false;

    //cooldown atk
    private float _coolDownTime = 0f;
    private float timer = 0f; 
    private void OnEnable() {
        _coolDownTime = _cardRefence.GetAtkSpeed();
        Move();
    }
    public void Move(){
        Vector3 targetTile;
        if(_user == PlayerCTL.Instance.GetId()){
            targetTile = gameObject.transform.parent.transform.position + Vector3.right;
        }else{
            targetTile = gameObject.transform.parent.transform.position + Vector3.left;
        }
        //verification of end arena
        if(targetTile.x >= GameCTL.Instance.GetGrid().GetColumns() || targetTile.x < 0){
            _isInCombatWithTheCastle = true;
        }
        else if(GameCTL.Instance.GetGrid().GetTiles()[(int)targetTile.x,(int)targetTile.z].GetIsUsed()){
            _isInCombat = true;
        }else{
            _isInCombat = false;
            gameObject.transform.parent.gameObject.GetComponent<Tile>().FreeUnit();
            gameObject.transform.parent = GameCTL.Instance.GetGrid().GetTiles()[(int)targetTile.x,(int)targetTile.z].transform;
            GameCTL.Instance.GetGrid().GetTiles()[(int)targetTile.x,(int)targetTile.z].SetUnit(this);
            GameCTL.Instance.GetGrid().GetTiles()[(int)targetTile.x,(int)targetTile.z].SetIsUsed(true);
            StartCoroutine(moveToTile(gameObject.transform,
                                      GameCTL.Instance.GetGrid().GetTiles()[(int)targetTile.x,
                                      (int)targetTile.z].GetUnitPostion().position, 1f/_cardRefence.GetMoveSpeed()));
        }
    }
    void Update()
    {
        if(_isInCombat && Time.time > timer){
            timer = Time.time + _coolDownTime;
            _actions.Attacking(_user,transform.parent.gameObject.GetComponent<Tile>(),_cardRefence.GetAtkRange(),
                                Resources.Load("Prefabs/Vfxs/"+_cardRefence.GetAtkVfxId().ToString()) as GameObject);
            Move();
        }else if(_isInCombatWithTheCastle && Time.time > timer){
            timer = Time.time + _coolDownTime;
            _actions.AttackingTheMainTower(_user,transform.parent.gameObject.GetComponent<Tile>(),
                                Resources.Load("Prefabs/Vfxs/"+_cardRefence.GetAtkVfxId().ToString()) as GameObject);
        }
    }
    IEnumerator moveToTile(Transform fromPosition, Vector3 toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (_isMoving)
        {
            yield break; ///exit if this is still running
        }
        _isMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector3.Lerp(startPos,
                                                 new Vector3(toPosition.x,startPos.y,toPosition.z), 
                                                 counter / duration);
            yield return null;
        }
        _isMoving = false;
        Move();
    }
}
