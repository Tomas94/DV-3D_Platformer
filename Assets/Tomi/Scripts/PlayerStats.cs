using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerStats : Entity
{
    PMovement _playerMov;
    PlayerAttack _playerAtk;
    PlayerView _playerView;
    Dash _playerDash;

    [Header("Variables Dash")]
    [SerializeField] float _dashSpeed;
    [SerializeField] float _duration;
    [SerializeField] float _cooldownTime;

    public override void Awake()
    {
        base.Awake();
        _playerView = GetComponent<PlayerView>();
        _playerMov = GetComponent<PMovement>();
        _playerAtk = GetComponentInChildren<PlayerAttack>();
        _playerMov.Speed = _speed;
    }

    private void Update()
    {
        _playerView.MovementState(_playerMov.Direction != Vector3.zero);
        
        if (Input.GetKeyDown(KeyCode.R)) DashLearned(); 
        if(Input.GetKeyDown(KeyCode.T)) AttackLearned();

        if (Input.GetKeyDown(KeyCode.E)) _playerDash?.StartDash();
        if (Input.GetKeyDown(KeyCode.F)) _playerAtk?.Attack();
    }

    void DashLearned()
    {
        if(_playerDash != null) Destroy(_playerDash);
        _playerDash = gameObject.AddComponent<Dash>(); 
        _playerDash?.Inicializar(_dashSpeed, _duration, _cooldownTime, true, transform, this.GetComponent<Rigidbody>(), _playerMov);
    }

    void AttackLearned()
    {
        _playerAtk?.Inicializar(_damagePower, _atkCooldown, _atkDuration, true);
    }
}
