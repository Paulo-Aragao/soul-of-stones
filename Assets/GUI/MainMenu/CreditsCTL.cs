using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CreditsCTL : MonoBehaviour
{
    [SerializeField] private Button _BT_Next;
    [SerializeField] private Button _BT_Prev;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _profile_image;
    [SerializeField] private List<MemberOfEquipe> _members;
    [System.Serializable]
    public struct MemberOfEquipe
    {
        public string _name;
        public string _description;
        public Sprite _profile_image;
    }
    private int memberId = 0;
    // Start is called before the first frame update
    void Start()
    {   
        memberId = 0;
        _BT_Next.onClick.AddListener(NextMember);
        _BT_Prev.onClick.AddListener(PrevMember);
        //seting the initial profile member
        _BT_Prev.gameObject.SetActive(false);
        _name.text = _members[memberId]._name;
        _description.text = _members[memberId]._description;
        _profile_image.sprite = _members[memberId]._profile_image;
    }
    private void NextMember(){
        memberId++;
        if(memberId == _members.Count-1){
            _BT_Next.gameObject.SetActive(false);
            _BT_Prev.gameObject.SetActive(true);
        }else{
            _BT_Next.gameObject.SetActive(true);
            _BT_Prev.gameObject.SetActive(true);
        }
        _name.text = _members[memberId]._name;
        _description.text = _members[memberId]._description;
        _profile_image.sprite = _members[memberId]._profile_image;
    }
    private void PrevMember(){
        memberId--;
        if(memberId == 0){
            _BT_Next.gameObject.SetActive(true);
            _BT_Prev.gameObject.SetActive(false);
        }else{
            _BT_Next.gameObject.SetActive(true);
            _BT_Prev.gameObject.SetActive(true);
        }
        _name.text = _members[memberId]._name;
        _description.text = _members[memberId]._description;
        _profile_image.sprite = _members[memberId]._profile_image;
    }
}

