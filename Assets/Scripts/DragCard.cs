using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour ,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.localPosition;
        _originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        PlayerCTL.Instance.SetDragingCard(true);
        transform.localScale = transform.localScale * 0.5f;
    }
    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData){
        PlayerCTL.Instance.SetDragingCard(false);
        transform.localPosition = _originalPosition;
        transform.localScale = _originalScale;
        if(PlayerCTL.Instance.GetTargetTile() != null){
            PlayerCTL.Instance.GetTargetTile().GetUnit().gameObject.SetActive(true);
        }
    }
}
