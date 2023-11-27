using System;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Action<Transform> PickObject;
    public Action DropObject;

    [SerializeField] float _interactRange;
    [SerializeField] LayerMask _pushableLayer;
    [SerializeField] bool _isPicking;

    public bool IsPicking { get { return _isPicking; } }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PushableObjectInRange()) Picking();

        if (Input.GetKeyUp(KeyCode.Space) && _isPicking) Dropping();
    }

    void Picking()
    {
        PickObject?.Invoke(this.transform);
        _isPicking = true;
    }

    void Dropping()
    {
        DropObject?.Invoke();
        _isPicking = false;
    }

    public bool PushableObjectInRange()
    {
        if (_isPicking) return false;
        return Physics.Raycast(transform.position, transform.forward, _interactRange, _pushableLayer);
    }
}
