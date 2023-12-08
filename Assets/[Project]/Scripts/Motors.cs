using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motors : MonoBehaviour
{
    [SerializeField] private float _heatSpeed;
    [SerializeField] private float _heatDecay;
    [SerializeField] private float _timeBeforExplode = 10f;
    private float _heatValue;
    private bool _isDeathSoundPlayed;

    public void UpdateHeat(float speedFactor)
    {
        



        if(speedFactor > .9f)
        {
            _heatValue += Time.deltaTime * _heatSpeed;
        }
        else
        {
            if(_heatValue > 0)
                _heatValue -= Time.deltaTime * _heatDecay;
        }

        if(_heatValue > _timeBeforExplode)
        {
            if(GameManager.instance && !_isDeathSoundPlayed)
            {
                _isDeathSoundPlayed = true;
                GameManager.instance.ShipExplode();
            }
        }
    }

    public float GetHeatRatio()
    {
        return Mathf.InverseLerp(0, _timeBeforExplode, _heatValue);
    }
}