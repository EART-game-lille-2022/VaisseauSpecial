using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ShipMovement : MonoBehaviour
{
    [Header("Speed :")]
    [SerializeField] private float _speedMultiplier;

    [Header("Rotation :")]
    [SerializeField] private float _rotationSpeed;

    private float _rotateDirection;
    private float _rotationLeft;
    private float _rotationRight;
    private int _direction = 1;
    private float _speed;
    private float _speedLeft;
    private float _speedRight;

    public void ChangeDirection()
    {
        _direction = _direction == 1 ? -1 : 1;
    }

    public void UpdateRotationLeft(float value)
    {
        _rotationLeft = Mathf.Lerp(0, 90, value);
        print(_rotationLeft);
    }

    public void UpdateRotationRight(float value)
    {
        _rotationRight = Mathf.Lerp(0, -90, value);
        print(_rotationRight);
    }

    public void UpdateSpeedLeft(float value)
    {
        _speedLeft = value;
    }

    public void UpdateSpeedRight(float value)
    {
        _speedRight = value;
    }

    void Update()
    {
        _speed = Mathf.InverseLerp(0, 2, _speedLeft + _speedRight) * _speedMultiplier;
        transform.Translate(-Vector3.right * _speed * Time.deltaTime * _direction);

        _rotateDirection = (_rotationLeft + _rotationRight) * _rotationSpeed;
        transform.Rotate(Vector3.up * _rotateDirection * Time.deltaTime); 
    }
}
