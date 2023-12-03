using UnityEngine;

public class PlayerStats : Entity
{
    public Transform startPosition;

    PMovement _playerMov;
    PlayerAttack _playerAtk;
    PlayerView _playerView;
    public Dash _playerDash;
    bool _canMove = true;

    [Header("Variables Dash")]
    [SerializeField] float _dashSpeed;
    [SerializeField] float _duration;
    [SerializeField] float _cooldownTime;

    [Header("Botones")]
    [SerializeField] KeyCode _attackKey;
    [SerializeField] KeyCode _dashKey;

    public delegate void updateLifeBar();
    public event updateLifeBar actualizarVida;

    public override void Awake()
    {
        base.Awake();
        _playerView = GetComponent<PlayerView>();
        _playerMov = GetComponent<PMovement>();
        _playerAtk = GetComponentInChildren<PlayerAttack>();
        _playerMov.Speed = _speed;
    }

    private void Start()
    {
        DashLearned();
        AttackLearned();
    }

    private void Update()
    {
        _playerView.MovementState(_playerMov.Direction != Vector3.zero);
        if(!_canMove)return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1)) DashLearned(); 
        if(Input.GetKeyDown(KeyCode.Keypad2)) AttackLearned();

        if (Input.GetKeyDown(_dashKey)) _playerDash?.StartDash();
        if (Input.GetKeyDown(_attackKey)) _playerAtk?.Attack();
    }

    public override void TakeDamage(int damage)
    {
        if (_playerDash._isDashing) return;
        base.TakeDamage(damage);
        actualizarVida?.Invoke();
    }

    public override void Die()
    {
        base.Die();
        transform.position = startPosition.position;
    }


    void DashLearned()
    {
        if(_playerDash != null) Destroy(_playerDash);
        _playerDash = gameObject.AddComponent<Dash>(); 
        _playerDash?.Inicializar(_dashSpeed, _duration, _cooldownTime, true, transform, this.GetComponent<Rigidbody>(), _playerMov);
    }

    void AttackLearned()
    {
        _playerAtk?.Inicializar(_damagePower, _atkCooldown, _atkDuration, true);
    }

    void ChangeMoveState(bool canMove) => _canMove = canMove;

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
