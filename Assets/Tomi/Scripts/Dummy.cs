using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [SerializeField] protected int _maxHP;
    [SerializeField] public int _currentHP;
    public Renderer renderer;


    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        _currentHP = _maxHP;
    }

    public IEnumerator HItted()
    {    

        renderer.material.color = Color.red;
        yield return new WaitForSeconds(1);
        renderer.material.color = Color.white;
    }



    void Update()
    {
        if(_currentHP <= 0) gameObject.SetActive(false);
    }
}
