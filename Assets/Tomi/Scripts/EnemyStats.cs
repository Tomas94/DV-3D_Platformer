using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable
{
    [SerializeField] float _maxHP = 1;
    [SerializeField] float _currentHP;
    [SerializeField] float _bounceValue;



    private void Awake()
    {
        _currentHP = _maxHP;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void Die()
    {
        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        _currentHP--;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement _player = other.GetComponent<PlayerMovement>();
        if (_player != null)
        {
            if (_player._isFalling)
            {
                _player._rb.AddForce(Vector3.up * _bounceValue, ForceMode.Impulse);
                TakeDamage();
            }
        }
        
    }
}
