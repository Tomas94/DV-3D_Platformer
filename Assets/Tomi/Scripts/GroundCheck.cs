using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask _ground;
    Collider _currentground;
    public bool isGrounded;

    /*private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _ground) != 0)
        {
            Debug.Log("Entrando en " + other.name);
            if (_currentground != null) return;

            _currentground = other;
            isGrounded = true;

        }
    }
    */
    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _ground) != 0 && other == _currentground)
        {
            Debug.Log("Saliendo de " + other.name);
            isGrounded = false;
            _currentground = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & _ground) != 0)
        {
            if (_currentground != null || _currentground == other) return;

            _currentground = other;
            isGrounded = true;

        }
    }
}
