using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints; 
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _arrivalThreshold = 0.1f; 

    private int _currentWaypointIndex = 0;

    private void Update()
    {
        if (_waypoints.Length == 0)
            return;

        Transform targetWaypoint = _waypoints[_currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;
        
        if ((targetWaypoint.position - transform.position).sqrMagnitude <= _arrivalThreshold * _arrivalThreshold)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }
    }
}
