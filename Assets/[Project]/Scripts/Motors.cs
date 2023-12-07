using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motors : MonoBehaviour
{
    [SerializeField] private float _heatValue;

    public void UpdateHeat(float sliderValue)
    {
        print(sliderValue);
        if(sliderValue > .9f)
        {
            _heatValue += Time.deltaTime;
        }
    }
}
