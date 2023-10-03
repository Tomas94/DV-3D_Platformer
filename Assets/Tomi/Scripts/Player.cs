using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] float _maxHP;
    [SerializeField] float _currentHP;

    void Start()
    {
        _currentHP = _maxHP;
    }
 
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))TakeDamage();
    }

    public void Die()
    {
        Debug.Log("Game Over");
    }

    public void TakeDamage()
    {
        _currentHP--;
        if(_currentHP <= 0 ) Die();
    }
}
