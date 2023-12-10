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
    private GameObject _asteroidHit;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    [ContextMenu("lziuhrgiuzhgiuh")]
    public void Shoot(Vector3 wolrdTargetPosition, GameObject asteroidHit)
    {
        AudoiManager.instance.SFX(AudoiManager.instance.CANNON_SHOOT);
        print("Shoot !");
        _line.enabled = true;
        _line.SetPosition(0, transform.position + Vector3.up * 10);
        _line.SetPosition(1, wolrdTargetPosition);

        time = _laserDuration;
        _asteroidHit = asteroidHit;
    }

    void Update()
    {
        if(!_line.enabled)
            return;

        time -= Time.deltaTime;
        float factor = 1 - (time / _laserDuration);

        _line.widthMultiplier = _sizeCurve.Evaluate(factor) * _laserwight;

        if(_sizeCurve.Evaluate(factor) > .8f && _asteroidHit)
        {
            _asteroidHit.GetComponent<AsteroidLife>().Demolish();
            _asteroidHit = null;
        }

        if(time < 0)
            _line.enabled = false;
    }
}
