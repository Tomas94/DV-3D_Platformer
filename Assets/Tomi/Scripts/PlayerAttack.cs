using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Weapon _equippedWeapon;

    BoxCollider _attackPoint;
    float _cooldown;
    float _duration;
    bool _canAttack;

    private void Awake()
    {
        _attackPoint = GetComponent<BoxCollider>();
    }


    public void Attack()
    {
        if (!_canAttack) return;
        _canAttack = false;
        _attackPoint.enabled = true;
        StartCoroutine(AttackRefresh());
    }

    IEnumerator AttackRefresh()
    {
        yield return new WaitForSeconds(_duration);
        _attackPoint.enabled = false;
        var timer = 0f;

        while (timer < _cooldown)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _canAttack = true; 
    }

}
