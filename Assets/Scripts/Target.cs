using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TargetPoint[] _points;
    [SerializeField] private float _speed;

    private int _pointId = 0;
    private float _distanceError = 0.01f;

    private void Update()
    {
        if (_pointId >= _points.Length)
            _pointId = 0;

        Vector3 currentPosition = transform.position;
        Vector3 pointPosition = _points[_pointId].transform.position;

        pointPosition.y = currentPosition.y;
        currentPosition = Vector3.MoveTowards(currentPosition, pointPosition, _speed * Time.deltaTime);

        transform.position = currentPosition;
        transform.LookAt(pointPosition);

        float distanceSqr = (pointPosition - currentPosition).sqrMagnitude;

        if (distanceSqr < _distanceError)
            _pointId++;
    }
}