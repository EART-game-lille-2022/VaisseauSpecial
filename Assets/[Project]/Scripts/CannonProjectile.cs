using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    [SerializeField] private float _laserDuration;
    [SerializeField] private float _laserwight;
    [SerializeField] private AnimationCurve _sizeCurve;
    private LineRenderer _line;
    private float time;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    [ContextMenu("lziuhrgiuzhgiuh")]
    public void Shoot(Vector3 wolrdTargetPosition)
    {
        print("Shoot !");
        _line.enabled = true;
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, wolrdTargetPosition);

        time = _laserDuration;
    }

    void Update()
    {
        if(!_line.enabled)
            return;

        time -= Time.deltaTime;
        float factor = 1 - (time / _laserDuration);

        _line.widthMultiplier = _sizeCurve.Evaluate(factor) * _laserwight;

        if(time < 0)
            _line.enabled = false;
    }
}
