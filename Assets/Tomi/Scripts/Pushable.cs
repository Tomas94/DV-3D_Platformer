using UnityEngine;

public class Pushable : MonoBehaviour
{
    Rigidbody _rb;
    public bool _picked;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Picked(Transform picker)
    {
        transform.SetParent(picker);
        _rb.isKinematic = false;
        _picked = true;
        picker.GetComponent<Interact>().DropObject += Dropped;
    }

    public void Dropped()
    {
        _picked = false;
        transform.SetParent(null);
        _rb.isKinematic = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        Interact _player;
        if (other.TryGetComponent(out _player)) _player.StartInteraction += Picked;
    }

    private void OnTriggerExit(Collider other)
    {
        Interact _player;
        if (other.TryGetComponent(out _player)) _player.StartInteraction -= Picked;

    }
}
