using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerStats : Entity
{
    PMovement _movScript;
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
        _movScript = GetComponent<PMovement>();
        _movScript.Speed = _speed;
    }

    private void Update()
    {
        _playerView.MovementState(_movScript.Direction != Vector3.zero);
        if (Input.GetKeyDown(KeyCode.R)) DashLearned(); 
        if (Input.GetKeyDown(KeyCode.E)) _playerDash?.StartDash();
    }

    void DashLearned()
    {
        if(_playerDash != null) Destroy(_playerDash);
        _playerDash = gameObject.AddComponent<Dash>(); 
        _playerDash.Inicializar(_dashSpeed, _duration, _cooldownTime, true, transform, this.GetComponent<Rigidbody>(), _movScript);
    }
}
