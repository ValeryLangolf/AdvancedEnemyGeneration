using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private float _timeBetweenSpawns = 2f;
    [SerializeField, Range(0, 1f)] private float _delayAfterParticle = 0.5f;
    [SerializeField] private bool _isSpawns = true;

    private WaitForSeconds _waitBetweenSpawns;
    private WaitForSeconds _waitAfterParticle;

    private void Awake()
    {
        _waitAfterParticle = new WaitForSeconds(_delayAfterParticle);
        _waitBetweenSpawns = new WaitForSeconds(Mathf.Abs(_timeBetweenSpawns - _delayAfterParticle));
    }

    private void Start()
    {
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        while (_isSpawns)
        {
            yield return _waitBetweenSpawns;

            int id = Random.Range(0, _points.Length);
            SpawnPoint point = _points[id];

            point.ShowSpawn();

            yield return _waitAfterParticle;

            point.CreateEnemy();
        }
    }
}