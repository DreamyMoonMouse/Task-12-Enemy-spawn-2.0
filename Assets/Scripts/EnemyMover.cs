using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Transform _target;

    private void Update()
    {
        if (_target == null) return;
        
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}