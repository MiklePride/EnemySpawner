using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Min(1)] private float _speed;

    private Transform _targetPoint;

    private void Update()
    {
        if (_targetPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
            transform.LookAt(_targetPoint);
        }
    }

    public void GetTargetPoint(Transform targetPoint)
    {
        _targetPoint = targetPoint;
    }
}
