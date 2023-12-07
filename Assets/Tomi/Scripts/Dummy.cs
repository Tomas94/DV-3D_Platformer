using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [SerializeField] protected int _maxHP;
    [SerializeField] public int _currentHP;
    public Renderer Renderer;
    public Color _colorDaño;

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        _currentHP = _maxHP;
    }

    public IEnumerator HItted()
    {    

        Renderer.material.color = _colorDaño;
        yield return new WaitForSeconds(1);
        Renderer.material.color = Color.white;
    }

    void Update()
    {
        if(_currentHP <= 0) gameObject.SetActive(false);
    }
}
