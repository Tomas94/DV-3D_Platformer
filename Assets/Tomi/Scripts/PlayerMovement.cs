using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform _groundCheck;
    [SerializeField] Transform _shadow;
    [SerializeField] LayerMask _ground;

    Rigidbody _rb;

    [SerializeField] Vector3 _direction;
    [SerializeField] Vector3 velocity;

    [SerializeField] float _speed;
    [SerializeField] float _jumpDuration;
    [SerializeField] float _jumpForce;
    [SerializeField] float _fallSpeed;

    [SerializeField] bool _isFalling;
    [SerializeField] bool _isJumping;
    [SerializeField] bool _isGrounded;



    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = DirectionVector();
        _isGrounded = Physics.Raycast(_groundCheck.position, _groundCheck.up * -1, 0.2f, _ground);

        ShadowRaycast();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) StartCoroutine("Jump");
        if (_isGrounded) _isFalling = false;
        if (!_isGrounded && !_isJumping) Fall();
     
    }

    void FixedUpdate()
    {
        if (_isGrounded) _rb.velocity = _direction * _speed;
        else
        {
            _rb.velocity = new Vector3(_direction.x * _speed, _rb.velocity.y, _direction.z * _speed);
        }
    }

    Vector3 DirectionVector()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        return dir;
    }

    IEnumerator Jump()
    {
        _isJumping = true;
       // _isFalling = false;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(_jumpDuration);
        _isJumping = false;
       // _isFalling = true;
    }

    void Fall()
    {
        _rb.AddForce(_fallSpeed * Physics.gravity);
        _isFalling = true;
    }

    public void ShadowRaycast()
    {
        RaycastHit hit;
        Ray _shadowray = new Ray(_groundCheck.position, _groundCheck.up * -1);
        if (Physics.Raycast(_shadowray, out hit))
        {
            _shadow.position = hit.point + Vector3.up;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_groundCheck.position, _groundCheck.position + Vector3.down * 0.2f );
    }
}
