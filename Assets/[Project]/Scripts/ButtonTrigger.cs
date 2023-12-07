using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    public UnityEvent _onButtonActivate;
    private bool _isButtonTrigger = true;
    void FixedUpdate()
    {
        if(transform.localPosition.z < 0.1 && !_isButtonTrigger){
            _onButtonActivate.Invoke();
            _isButtonTrigger = true;
        }
        if(transform.localPosition.z > 0.2){
            _isButtonTrigger = false;
        }
    }
}
