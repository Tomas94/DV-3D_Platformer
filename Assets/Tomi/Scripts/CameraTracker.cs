using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [Header("Smoothing Values")]
    [Range(0.01f, .125f)] [SerializeField] private float _smoothSpeed = .075f;

    [SerializeField] Transform _target;
    private Vector3 _desiredPos, _smoothedPos;
    public Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        _desiredPos = _target.position + _offset;
        _smoothedPos = Vector3.Lerp(transform.position, _desiredPos, _smoothSpeed);
        transform.position = _smoothedPos;
    }
}
