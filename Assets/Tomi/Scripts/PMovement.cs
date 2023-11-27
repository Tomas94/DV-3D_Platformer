using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PMovement : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] GroundCheck _groundCheck;

    Vector3 _direction;
    Vector3 _fallVector;
    
    [SerializeField] float _speed;
    [SerializeField] float _gravityForce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _fallVector = FallingForce();
        _direction = DirVector();

        if (_direction == Vector3.zero) { _rb.velocity = Vector3.zero; }

    }

    private void FixedUpdate()
    {
        _rb.velocity = (_direction + _fallVector) * _speed;
    }

    public Vector3 DirVector()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        dir = Quaternion.Euler(0, 45, 0) * dir;

        if (dir != Vector3.zero) transform.forward = dir;

        return dir.normalized;
    }

    Vector3 FallingForce()
    {
        if (!_groundCheck.isGrounded) return Vector3.down * _gravityForce;
        return Vector3.zero;
    }

}
