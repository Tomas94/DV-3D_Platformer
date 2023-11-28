using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    PMovement _movScript;
    Dash _playerDash;

    [Header("Stats Player")]
    [SerializeField] float _speed;
    [SerializeField] int _maxHP;
    [SerializeField] int _currentHP;
    [SerializeField] int _damagePower;

    [Header("Variables Dash")]
    [SerializeField] float _dashSpeed;
    [SerializeField] float _duration;
    [SerializeField] float _cooldownTime;

    private void Awake()
    {
        _movScript = GetComponent<PMovement>();
        _movScript.Speed = _speed;
        _currentHP = _maxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) DashAcquire(); 
        if (Input.GetKeyDown(KeyCode.E)) _playerDash?.StartDash();
    }

    public void TakeDamage(int damage)
    {

    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    void DashAcquire()
    {
        if(_playerDash != null) Destroy(_playerDash);
        _playerDash = gameObject.AddComponent<Dash>(); 
        _playerDash.Inicializar(_dashSpeed, _duration, _cooldownTime, true, transform, this.GetComponent<Rigidbody>(), _movScript);
    }
}
