using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onButtonActivate;
    [SerializeField] private UnityEvent _onButtonRelease;
    public Transform _plunger;
    private bool _isButtonTrigger;

    public UnityEvent OnButtonActivate { get => _onButtonActivate; set => _onButtonActivate = value; }
    public UnityEvent OnButtonRelease { get => _onButtonRelease; set => _onButtonRelease = value; }

    void FixedUpdate()
    {
        if (_plunger.localPosition.z < 0.01 && !_isButtonTrigger)
        {
            _onButtonActivate.Invoke();
            _isButtonTrigger = true;
            // print("trigger");
        }
        
        if (_plunger.localPosition.z > 0.02 && _isButtonTrigger)
        {
            _onButtonRelease.Invoke();
            _isButtonTrigger = false;
            // print("release");
        }
    }
}
