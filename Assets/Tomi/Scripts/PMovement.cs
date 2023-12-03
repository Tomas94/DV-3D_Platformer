using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PMovement : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] GroundCheck _groundCheck;
    Interact _pInteract;
    Vector3 _direction;
    Vector3 _fallVector;

    float _speed;
    [SerializeField] int _movAngle;
    [SerializeField] float _gravityForce;
    [SerializeField] float _pullForce;
    [SerializeField] float _pushForce;
    float dotValue;
    public bool _canMove = true;

    public float Speed { set { _speed = value; } }
    public Vector3 Direction { get { return _direction; } }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _pInteract = GetComponentInChildren<Interact>();
    }

    void Update()
    {
        _fallVector = FallingForce();
        _direction = DirVector();
        FacingDirection(_direction, _pInteract.IsPicking);

        dotValue = Vector3.Dot(_direction, transform.forward);

        if (_direction == Vector3.zero) { _rb.velocity = Vector3.zero; }

    }

    private void FixedUpdate()
    {
        FixedMove();
    }

    public Vector3 DirVector()
    {
        if(!_canMove) return Vector3.zero;
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        dir = Quaternion.Euler(0, _movAngle, 0) * dir;
        return dir.normalized;
    }

    void FacingDirection(Vector3 dir, bool movModificator)
    {
        if (movModificator)
        {
            return;
        }
        if (dir != Vector3.zero) transform.forward = dir;
    }

    public void FixedMove()
    {
        if (!_pInteract.IsPicking)
        {
            _rb.velocity = (_direction + _fallVector) * _speed;
            return;
        }

        if (_pInteract.IsPicking)
        {
            if (dotValue >= 0.9f) _rb.velocity = (_direction + _fallVector) * _pushForce;
            else if (dotValue <= -0.9f) _rb.velocity = (_direction + _fallVector) * _pullForce;
            else _rb.velocity = Vector3.zero;
        }
    }

    Vector3 FallingForce()
    {
        if (!_groundCheck.isGrounded) return Vector3.down * _gravityForce;
        return Vector3.zero;
    }

    void ChangeMoveState(bool canMove)
    {
        _canMove = canMove;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            DialogBox interactableCharacter = other.GetComponent<DialogBox>();
            interactableCharacter.InteraccionDialogo += ChangeMoveState;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            DialogBox interactableCharacter = other.GetComponent<DialogBox>();
            interactableCharacter.InteraccionDialogo -= ChangeMoveState;
        }
    }
}
