using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.VersionControl;
public class MoveUnit : MonoBehaviour
{
    private bool _isMoving = false;
    public void Move(Unit unit,Tile targetMoveTile){
        Astar astar = new Astar();
        System.Tuple<int, int> tilePosition = astar.UnitAStar((int)transform.parent.position.x,(int)transform.parent.position.z,
                                                            (int)targetMoveTile.transform.position.x,(int)targetMoveTile.transform.position.z);
        Debug.Log( tilePosition.Item1+","+tilePosition.Item2);
        StartCoroutine(moveToTile(gameObject.transform,
                                GameCTL.Instance.GetGrid().GetTiles()[tilePosition.Item1,tilePosition.Item2].GetUnitPostion().position, 1.0f));
        Debug.Log("coroutina termiou");
        unit.transform.parent = GameCTL.Instance.GetGrid().GetTiles()[tilePosition.Item1,tilePosition.Item2].transform;
    }
    void Update()
    {
        if(Input.GetKeyDown("s")){
            Move(gameObject.GetComponent<Unit>(),GameCTL.Instance.GetGrid().GetTiles()[6,5]);
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
    }
}
