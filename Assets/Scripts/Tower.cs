using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _hp = 500;
    [SerializeField] private Slider _lifeBar;
    public int GetHp(){
        return _hp;
    }
    public void SetHp(int hp){
        _hp = hp;
    }
    void Start()
    {
        _lifeBar.value = _hp;
    }
    public void TakeDamage(int dmg){
        _hp -= dmg;
        _lifeBar.value = _hp;
    }
}
