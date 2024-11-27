using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Target _target;

    private void Update()
    {
        if (_target == null)
            return;

        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = _target.transform.position;

        targetPosition.y = currentPosition.y;
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, _speed * Time.deltaTime);

        transform.position = currentPosition;
        transform.LookAt(targetPosition);
    }

    public void Inicialize(Target target)
    {
        _target = target;
    }
}