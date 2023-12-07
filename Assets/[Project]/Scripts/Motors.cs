using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motors : MonoBehaviour
{
    [SerializeField] private float _heatValue;

    public void UpdateHeat(float speedFactor)
    {
        print(speedFactor);
        if(speedFactor > .9f)
        {
            _heatValue += Time.deltaTime;
        }

        if(_heatValue > 1)
        {
            Destroy(gameObject);
        }
    }
}
