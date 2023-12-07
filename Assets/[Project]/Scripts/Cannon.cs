using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Cannon : MonoBehaviour
{
    [SerializeField] private XRGripButton _buttonUp;
    [SerializeField] private XRGripButton _buttonDown;
    [SerializeField] private XRGripButton _buttonLeft;
    [SerializeField] private XRGripButton _buttonRight;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed;
    private Vector3 _rotateVector;

    void Start()
    {
        _buttonUp.onPress.AddListener(LookUp);
        _buttonUp.onRelease.AddListener(StopX);

        _buttonDown.onPress.AddListener(LookDown);
        _buttonDown.onRelease.AddListener(StopX);

        _buttonLeft.onPress.AddListener(LookLeft);
        _buttonLeft.onRelease.AddListener(StopY);

        _buttonRight.onPress.AddListener(LookRight);
        _buttonRight.onRelease.AddListener(StopY);
    }

    void LookUp()
    {
        _rotateVector.x = -1;
    }

    void LookDown()
    {
        _rotateVector.x = 1;
    }

    void LookRight()
    {
        _rotateVector.y = 1;
    }

    void LookLeft()
    {
        _rotateVector.y = -1;
    }

    void StopX()
    {
        _rotateVector.x = 0;
    }

    void StopY()
    {
        _rotateVector.y = 0;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, _rotateVector.y, 0) * _speed);
        _cameraTransform.Rotate(new Vector3(_rotateVector.x, 0, 0) * _speed);
    }
}
