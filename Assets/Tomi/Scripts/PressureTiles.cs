using UnityEngine;

public class PressureTiles : MonoBehaviour
{
    public Transform _tileTransform;
    bool _active;

    private void Awake()
    {
        _tileTransform = transform.parent.GetComponent<Transform>();

    }

    private void OnTriggerStay(Collider other)
    {
       if(!_active) Activate();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_active) Desactivate();
    }

    void Activate()
    {
        _tileTransform.position += Vector3.down * 0.5f;
        _active = true;
    }

    private void Desactivate()
    {
        _tileTransform.position += Vector3.up * 0.5f;
        _active = false;
    }


}
