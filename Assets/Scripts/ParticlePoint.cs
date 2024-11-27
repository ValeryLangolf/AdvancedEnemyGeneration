using UnityEngine;

public class ParticlePoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public void Play()
    {
        _particle.Play();
    }
}