using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{
    Transform _transformParent;
    [SerializeField] Transform _player;
    [SerializeField] float _minRangeOfCreation;
    [SerializeField] float _maxRangeOfCreation; 
    [Header("Rocks")]
    [SerializeField] GameObject _spaceRockPrefab;
    [Range(10f, 300f)][SerializeField] int _numberOfRocks;
    [SerializeField] public List<AsteroidLife> _asteroids;

    private void Start()
    {
        for (int i = 0; i < _numberOfRocks; i++)
        {
            _transformParent = _player.transform;
            GameObject spaceRock = Instantiate(_spaceRockPrefab, _transformParent.position + Random.insideUnitSphere * Random.Range(_minRangeOfCreation, _maxRangeOfCreation), _transformParent.rotation);
            spaceRock.transform.parent = transform;
            _asteroids.Add(spaceRock.GetComponent<AsteroidLife>());
        }
    }

    private void Update()
    {
        foreach (var Asteroid in _asteroids)
        {
            if ((Asteroid.transform.position - _player.position).magnitude > _maxRangeOfCreation)
            {
                Asteroid.transform.position = _player.position + Random.insideUnitSphere * Random.Range(_minRangeOfCreation, _maxRangeOfCreation);
            }
        }
    }
}
