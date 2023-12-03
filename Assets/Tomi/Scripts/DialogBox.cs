using UnityEngine;
using TMPro;
using System;

public class DialogBox : MonoBehaviour
{
    [SerializeField] bool _isActive;
    [SerializeField] bool _inRange;

    public LayerMask playerLayer;

    [Header("Referencia Componentes")]
    [SerializeField] Animator _chatBoxAnim;
    [SerializeField] Animator _chatCharacterAnim;
    [SerializeField] TextMeshProUGUI _characterName;
    [SerializeField] TextMeshProUGUI _dialog;
    [SerializeField] SpriteRenderer _dialogIcon;

    [Header("Textos")]
    [SerializeField] string _name;
    [TextArea(3, 10)]
    [SerializeField] string _msg;

    public Action<bool> InteraccionDialogo;

    void Start()
    {
        _isActive = false;
    }

    private void Update()
    {
        if (!_inRange) return;
        if (_inRange && Input.GetKeyDown(KeyCode.E))
        {
            InteraccionDialogo?.Invoke(_isActive);
            ChangeState();
            Debug.Log("Ejecuto la funcion");
        }
    }

    public void ChangeState()
    {
        if (_isActive)
        {
            DesactivarDialogo();
            return;
        }
        if (!_isActive)
        {
            ActivarDialogo();
            return;
        }
    }

    public void ActivarDialogo()
    {
        _isActive = true;
        _chatBoxAnim.SetBool("isActive", _isActive);
        _chatCharacterAnim.SetBool("isActive", _isActive);
        _characterName.text = _name;
        _dialog.text = _msg;

    }

    public void DesactivarDialogo()
    {
        _isActive = false;
        _chatBoxAnim.SetBool("isActive", _isActive);
        _chatCharacterAnim.SetBool("isActive", _isActive);
        _characterName.text = null;
        _dialog.text = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable")) _inRange = true;
        _dialogIcon.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable")) _inRange = false;
        _dialogIcon.enabled = false;

    }
}
