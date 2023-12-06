using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 rotateVector;
    public void ChangeHorizontalDirection(float value)
    {
        rotateVector.y = value;
    }

    void Update()
    {
        transform.Rotate(rotateVector * _speed);
    }
}
