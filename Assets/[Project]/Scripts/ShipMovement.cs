using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed;
    public int direction;
    public float rotateDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void AddSpeed()
    {
        speed++;
    }

    public void RemoveSpeed()
    {
        speed--;
        if(speed < 0)
            speed = 0;
    }

    public void ChangeDirection()
    {
        direction = direction == 1 ? -1 : 1;
    }

    public void RotateRight()
    {
        rotateDirection = 100;
    }

    public void RotateLeft()
    {
        rotateDirection = -100;
    }

    public void StopRotate()
    {
        rotateDirection = 0;
    }

    void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime * direction);
        transform.Rotate(Vector3.up * rotateDirection * Time.deltaTime);    
    }
}
