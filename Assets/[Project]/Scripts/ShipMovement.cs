using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ShipMovement : MonoBehaviour
{
    [Header("Speed :")]
    [SerializeField] private float _horizontalSpeedMultiplier;
    [SerializeField] private float _verticalSpeedMultiplier;

    [Header("Rotation :")]
    [SerializeField] private float _rotationSpeed;

    private float _rotateDirection;
    private float _rotationLeft;
    private float _rotationRight;
    private int _direction = 1;
    private float _verticalSpeed;
    private float _speedLeft;
    private float _speedRight;

    public void OnChangeVerticalMove(float value){
        _verticalSpeed = Mathf.Lerp(-1, 1, value);
    }

    public void ChangeDirection()
    {
        _direction = _direction == 1 ? -1 : 1;
    }

    public void UpdateRotationLeft(float value)
    {
        _rotationLeft = Mathf.Lerp(0, 90, value);
    }

    public void UpdateRotationRight(float value)
    {
        _rotationRight = Mathf.Lerp(0, -90, value);
    }

    public void UpdateSpeedLeft(float value)
    {
        _speedLeft = value;
    }

    public void UpdateSpeedRight(float value)
    {
        _speedRight = value;
    }

    void FixedUpdate()
    {
        HorizontalMove();
        VerticalMovement();
        HorizontalRotation();
    }

    private void VerticalMovement()
    {
        // _rigidbody.AddForce(transform.up * _verticalSpeed * _verticalSpeedMultiplier, ForceMode.Force);
        transform.Translate(Vector3.up * _verticalSpeed * Time.fixedDeltaTime * _verticalSpeedMultiplier);
    }

    private void HorizontalRotation()
    {
        _rotateDirection = (_rotationLeft + _rotationRight) * _rotationSpeed;
        transform.Rotate(Vector3.up * _rotateDirection * Time.fixedDeltaTime);
    }

    private void HorizontalMove()
    {
        // _rigidbody.AddForce(transform.right * _horizontalSpeed * _direction, ForceMode.Force);
        float speed = Mathf.InverseLerp(0, 2, _speedLeft + _speedRight) * _horizontalSpeedMultiplier;
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime * _direction);
    }
}
