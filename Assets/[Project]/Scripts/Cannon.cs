using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    private RaycastHit _hit;


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
        Physics.Raycast(transform.position, _cameraTransform.forward, out _hit, Mathf.Infinity);
        

        if(_hit.collider)
        {
            _cannonProjectile.Shoot(_hit.point, _hit.collider.gameObject);
        }
        else
        {

            print("Nothing hit");
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, _rotateVector.y, 0) * _speed);
        _cameraTransform.Rotate(new Vector3(_rotateVector.x, 0, 0) * _speed);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10000);
    }
}
