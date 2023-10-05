using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] float _maxHP;
    [SerializeField] float _currentHP;
    [SerializeField] TextMeshProUGUI life;

    void Start()
    {
        _currentHP = _maxHP;
    }
 
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))TakeDamage();
        life.text = "HP: " + _currentHP.ToString();
    }

    public void Die()
    {
        transform.position = GameManager.lastCheckpoint;
        Debug.Log("Game Over");
        _currentHP = _maxHP;
    }

    public void TakeDamage()
    {
        _currentHP--;
        if(_currentHP <= 0 ) Die();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Die();
        }
    }
}
