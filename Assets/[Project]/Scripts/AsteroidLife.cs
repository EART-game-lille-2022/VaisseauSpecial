using UnityEngine;

public class AsteroidLife : MonoBehaviour
{
    [SerializeField] float _startSpeed;
    [SerializeField] private ParticleSystem _deathParticle;
    private MeshRenderer _renderer;
    private Collider _collider;

    void Start()
    {
        Impulse(_startSpeed);
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    public void Demolish()
    {
        if (_deathParticle)
        {
            _deathParticle.Play();
            _renderer.enabled = false;
            _collider.enabled = false;
            Destroy(gameObject, _deathParticle.main.duration);
            return;
        }

        Destroy(gameObject);
    }
    void Impulse(float Strength)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.velocity = Random.insideUnitSphere * Random.Range(-Strength, Strength);
        rb.angularVelocity = Random.insideUnitSphere * Random.Range(-Strength, Strength);
        
    }
}
