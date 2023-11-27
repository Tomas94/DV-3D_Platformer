using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PMovement : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField] float _speed;
    [SerializeField] Vector3 _direction;
    [SerializeField] Vector3 _fallDir;
    [SerializeField] float _gravityForce;
    [SerializeField] GroundCheck groundCheck;
    public LayerMask groundLayer;
   // public SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded())
        {
            _fallDir = FallingForce();
           // _spriteRenderer.color = Color.white;
        }
        else
        {
            _fallDir = Vector3.zero;
           // _spriteRenderer.color = Color.red;
        }
        _direction = InputVector();
        if (_direction == Vector3.zero) { _rb.velocity = Vector3.zero; }


    }

    private void FixedUpdate()
    {
        _rb.velocity = (_direction + _fallDir) * _speed;
    }

    Vector3 InputVector()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        dir = Quaternion.Euler(0, 45, 0) * dir;
        if (dir != Vector3.zero) transform.forward = dir;
        return dir.normalized;
    }

    bool IsGrounded()
    {
        return groundCheck.isGrounded;
    }

    Vector3 FallingForce()
    {
        return Vector3.down * _gravityForce;
    }


    Vector3 Move(Vector3 dir)
    {
        Vector3 direccionDelMundo = transform.TransformDirection(dir);
        return direccionDelMundo;
    }

}
