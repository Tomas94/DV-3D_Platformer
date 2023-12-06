using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [SerializeField] bool _isActive;
    [SerializeField] bool _inRange;

    public LayerMask playerLayer;

    [Header("Referencia Componentes")]
    [SerializeField] Sprite NPCSprite;
    [SerializeField] Image npcimagecontainer;
    [SerializeField] Animator _chatBoxAnim;
    [SerializeField] Animator _chatCharacterAnim;
    [SerializeField] TextMeshProUGUI _characterName;
    [SerializeField] TextMeshProUGUI _dialog;
    // [SerializeField] SpriteRenderer _dialogIcon;

    [Header("Textos")]
    [SerializeField] string _name;
    [TextArea(3, 10)]
    [SerializeField] string _msg;

    public bool teachDash;
    public bool teachAttack;

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
        npcimagecontainer.sprite = NPCSprite;
        _isActive = true;
        _chatBoxAnim.SetBool("isActive", _isActive);
        _chatCharacterAnim.SetBool("isActive", _isActive);
        _characterName.text = _name;
        _dialog.text = _msg;

    }

    public void DesactivarDialogo()
    {
        if (teachAttack) Manager.Instance.attackLearned = true;
        if (teachDash) Manager.Instance.dashLearned = true;
        _isActive = false;
        _chatBoxAnim.SetBool("isActive", _isActive);
        _chatCharacterAnim.SetBool("isActive", _isActive);
        _characterName.text = null;
        _dialog.text = null;
        NextSpot();
    }

    public void NextSpot()
    {
        Manager.Instance.NPCspots[Manager.Instance.currentNPCSpot].SetActive(false);
        if (Manager.Instance.currentNPCSpot < Manager.Instance.NPCspots.Count - 1)
        {
            Manager.Instance.currentNPCSpot += 1;
            Manager.Instance.NPCspots[Manager.Instance.currentNPCSpot].SetActive(true);
        }
        else
        {
            Manager.Instance.levelComplete = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable")) _inRange = true;
        // _dialogIcon.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable")) _inRange = false;
        //_dialogIcon.enabled = false;

    }
}
