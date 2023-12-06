using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Weapon _equippedWeapon;    a crear a futuro clase Weapon

    BoxCollider _attackPoint;
    MeshRenderer _attackMeshRenderer;
    int _damage;
    float _cooldown;
    float _duration;
    bool _canAttack;

    public void Inicializar(int damage, float cooldown, float duration, bool canAttack)
    {
        _damage = damage;
        _cooldown = cooldown;
        _duration = duration;
        _canAttack = canAttack;
    }


    private void Awake()
    {
        _attackPoint = GetComponent<BoxCollider>();
        _attackMeshRenderer = GetComponent<MeshRenderer>();
    }


    public void Attack()
    {
        if (!_canAttack) return;
        _canAttack = false;
        _attackPoint.enabled = true;
        _attackMeshRenderer.enabled = true;
        StartCoroutine(AttackRefresh());
    }

    IEnumerator AttackRefresh()
    {
        yield return new WaitForSeconds(_duration);
        _attackPoint.enabled = false;
        _attackMeshRenderer.enabled = false;
        var timer = 0f;

        while (timer < _cooldown)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dummy"))
        {
            other.GetComponent<Dummy>()._currentHP -= 1;
            StartCoroutine(other.GetComponent<Dummy>().HItted());
        }
    }
}
