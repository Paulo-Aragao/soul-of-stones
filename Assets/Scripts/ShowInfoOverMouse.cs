using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowInfoOverMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        var text = "";
        switch (GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetCardType())
        {
            case "unity":
                switch (GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetUnityType())
                {
                    case "defence":
                        text = GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetName() + "\n\n" +
                        "Health Points : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetHp() + '\n'+
                        "Damage Attack : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetAtkDamage() + '\n'+
                        "Attack Speed : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetAtkSpeed(); 
                        break;
                    case "beater":
                        text = GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetName() + "\n\n" +
                        "Health Points : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetHp() + '\n'+
                        "Damage Attack : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetAtkDamage() + '\n'+
                        "Attack Speed : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetAtkSpeed() + '\n' +
                        "Move Speed : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetMoveSpeed(); 
                        break;
                    case "healer":
                        text = GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetName() + "\n\n" +
                        "Health Points : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetHp() + '\n'+
                        "Heal Power : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetHealPower() + '\n'+
                        "Heal Speed : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetHealSpeed(); 
                        break;
                    case "wall":
                        text = GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetName() + "\n\n" +
                        "Health Points : "+GameCTL.Instance.GetListOfAllCards()[gameObject.GetComponent<CardUI>().GetCardId()].GetHp() + '\n'; 
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        UICTL.Instance.SetCardInfo(text);
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UICTL.Instance.SetCardInfo("");
        isOver = false;
    }
}
