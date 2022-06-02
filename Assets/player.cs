using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _cameraOffset;

    [SerializeField] private float _smoothSpeed = 0.125f;
    void Update()
    {
        transform.Translate(-transform.forward * _speed * Time.deltaTime);
    }
    void LateUpdate()
    {
        Vector3 desirePosition = transform.position + _cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, _smoothSpeed);
        _camera.transform.position = smoothedPosition;
    }
}
