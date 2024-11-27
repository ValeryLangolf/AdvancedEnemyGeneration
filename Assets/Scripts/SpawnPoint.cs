using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Target _target;
    [SerializeField] private ParticlePoint _particle;

    public void ShowSpawn()
    {
        _particle.Play();
    }

    public void CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity, transform);
        enemy.Inicialize(_target);
    }
}