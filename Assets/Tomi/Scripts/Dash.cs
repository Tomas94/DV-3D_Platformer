using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    float _dashSpeed;
    float _duration;
    float _cooldownTime;
    bool _canDash;
    PMovement _pMov;
    Transform _player;
    Rigidbody _rb;

    public void Inicializar(float dashSpeed, float duration, float cooldown, bool canDash, Transform player, Rigidbody rb, PMovement pMov)
    {
        _dashSpeed = dashSpeed;
        _duration = duration;
        _cooldownTime = cooldown;
        _canDash = canDash;
        _player = player;
        _rb = rb;
        _pMov = pMov;
    }

    public void StartDash()
    {
        if (!_canDash) return;
        _canDash = false;
        _pMov.enabled = false;
        _rb.AddForce(_player.forward * _dashSpeed, ForceMode.Impulse);
        StartCoroutine(StopDash());
        StartCoroutine(CooldownReset());
    }

    IEnumerator StopDash()
    {
        var timer = 0f;
        while (timer <= _duration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _pMov.enabled = true;
    }

    IEnumerator CooldownReset()
    {
        var timer = 0f;
        while (timer <= _cooldownTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _canDash = true;
    }
}
