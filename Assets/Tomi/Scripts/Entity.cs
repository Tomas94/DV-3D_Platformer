using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] protected int _maxHP;
    [SerializeField] protected int _currentHP;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damagePower;

    virtual public void Awake()
    {
        _currentHP = _maxHP;
    }
    
    virtual public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0) Die();
    }

    virtual public void Die()
    {
        
    }
}
