using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    public UnityEvent _onButtonActivate;
    public Transform _plunger;
    private bool _isButtonTrigger;
    void FixedUpdate()
    {
        if(_plunger.localPosition.z < 0.01 && !_isButtonTrigger){
            _onButtonActivate.Invoke();
            _isButtonTrigger = true;
        }
        if(_plunger.localPosition.z > 0.02){
            _isButtonTrigger = false;
        }
        print(_isButtonTrigger);
    }
}
