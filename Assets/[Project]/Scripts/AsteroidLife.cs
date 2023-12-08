using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathParticle;
    private MeshRenderer _renderer;
    private Collider _collider;

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    public void Demolish()
    {
        if(_deathParticle)
        {
            _deathParticle.Play();
            _renderer.enabled = false;
            _collider.enabled = false;
            Destroy(gameObject, _deathParticle.main.duration);
            return;
        }

        Destroy(gameObject);
    }
}
