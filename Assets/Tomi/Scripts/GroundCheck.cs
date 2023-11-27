using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    
    [SerializeField] LayerMask _ground;
    Collider _currentground;
    

    private void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & _ground) != 0)
        {
            if (_currentground != null || _currentground == other) return;

            _currentground = other;
            isGrounded = true;

        }
    }
       private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & _ground) != 0 && other == _currentground)
        {
            isGrounded = false;
            _currentground = null;
        }
    }
}
