using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Cannon : MonoBehaviour
{
    [SerializeField] private CannonProjectile _cannonProjectile;
    [Header("Button Ref :")]
    [SerializeField] private ButtonTrigger _buttonUp;
    [SerializeField] private ButtonTrigger _buttonDown;
    [SerializeField] private ButtonTrigger _buttonLeft;
    [SerializeField] private ButtonTrigger _buttonRight;
    [SerializeField] private ButtonTrigger _buttonShoot;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed;
    private Vector3 _rotateVector;

    void Start()
    {
        _buttonUp.OnButtonActivate.AddListener(LookUp);
        _buttonUp.OnButtonRelease.AddListener(StopX);

        _buttonDown.OnButtonActivate.AddListener(LookDown);
        _buttonDown.OnButtonRelease.AddListener(StopX);

        _buttonLeft.OnButtonActivate.AddListener(LookLeft);
        _buttonLeft.OnButtonRelease.AddListener(StopY);

        _buttonRight.OnButtonActivate.AddListener(LookRight);
        _buttonRight.OnButtonRelease.AddListener(StopY);

        _buttonShoot.OnButtonActivate.AddListener(Shoot);
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

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity);

        if(hit.collider)
        {
            _cannonProjectile.Shoot(hit.point, hit.collider.gameObject);
        }
        else
            print("Nothing hit");

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, _rotateVector.y, 0) * _speed);
        _cameraTransform.Rotate(new Vector3(_rotateVector.x, 0, 0) * _speed);
    }
}
