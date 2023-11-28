using System;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Action<Transform> StartInteraction;
    public Action DropObject;

    [SerializeField] float _interactRange;
    [SerializeField] LayerMask _interactableLayer;
    [SerializeField] bool _isInteracting;

    public bool IsPicking { get { return _isInteracting; } }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PushableObjectInRange()) Interacting();

        if (Input.GetKeyUp(KeyCode.Space) && _isInteracting) Dropping();
    }

    void Interacting()
    {
        StartInteraction?.Invoke(this.transform);
        _isInteracting = true;
    }

    void Dropping()
    {
        DropObject?.Invoke();
        _isInteracting = false;
    }

    public bool PushableObjectInRange()
    {
        if (_isInteracting) return false;
        return Physics.Raycast(transform.position, transform.forward, _interactRange, _interactableLayer);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * _interactRange);
    }
}
