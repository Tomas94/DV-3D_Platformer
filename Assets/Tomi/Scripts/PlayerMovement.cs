using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Transform _groundCheck;
    [SerializeField] Transform _shadow;
    [SerializeField] LayerMask _ground;

    Rigidbody _rb;

    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] Vector3 _dir;
    [SerializeField] float _fallSpeed;
    
    [SerializeField] bool _isJumping;
    [SerializeField] bool _isFalling;


    [SerializeField] Vector3 velocity;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        velocity = _rb.velocity;
        ShadowRaycast();

        if(Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            StartCoroutine("Jump");
        }
        
        _dir = DirVector();

        if (IsGrounded())
        {
            Debug.Log("en el piso");
        }
        else
        {
            Debug.Log("en el aire");
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce( _dir * _speed);

        if(_isFalling) Fall();
        
        if (_dir != Vector3.zero)
        {
            transform.forward = _dir;
        }

    }

    Vector3 DirVector()
    {
        Vector3 dir = new Vector3(0,0,0);
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        return dir;
    }

    IEnumerator Jump()
    {
        //_isJumping = true;
        _isFalling = false;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        _rb.velocity = new Vector3(_rb.velocity.x,0, _rb.velocity.z);
        _isFalling = true;
    }

    void Fall()
    {
        if(_rb.velocity.y < 0)
        {
            _rb.AddForce(_fallSpeed * Physics.gravity);
        } 
    }

    bool IsGrounded()
    {
        return Physics.Raycast(_groundCheck.position, _groundCheck.up*-1, 0.2f, _ground);
    }

    public void ShadowRaycast()
    {
        RaycastHit hit;
        Ray _shadowray = new Ray(_groundCheck.position, _groundCheck.up * -1);
        if(Physics.Raycast(_shadowray, out hit))
        {
            _shadow.position = hit.point + Vector3.up;
        }
    }



    private void OnDrawGizmos()
    {
        Ray _shadowray = new Ray(_groundCheck.position, _groundCheck.up * -1);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_groundCheck.position, _groundCheck.up * -1*0.2f);
    }

}
