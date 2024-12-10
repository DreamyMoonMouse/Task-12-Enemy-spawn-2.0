using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target _target;

    public void Spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        if (enemy.TryGetComponent(out EnemyMover enemyMover))
        {
            enemyMover.SetTarget(_target.transform);
        }
    }
}
