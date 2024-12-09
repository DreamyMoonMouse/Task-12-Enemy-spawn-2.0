using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Target[] _targets;
    [SerializeField] private float _spawnInterval = 2f;

    private Coroutine _spawnCoroutine;
    
    private static float _lastSpawnTime;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        bool isRunning = true;
        
        while (isRunning)
        {
            float currentTime = Time.time;

            if (currentTime - _lastSpawnTime >= _spawnInterval)
            {
                _lastSpawnTime = currentTime;

                int spawnIndex = Random.Range(0, _spawnPoints.Length);
                Transform randomSpawnPoint = _spawnPoints[spawnIndex];
                Target target = _targets[spawnIndex];
                Enemy enemyPrefab = _enemyPrefabs[spawnIndex];
                Enemy enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

                if (enemy.TryGetComponent(out EnemyMover enemyMover))
                {
                    enemyMover.SetTarget(target.transform);
                }
            }

            yield return null;
        }
    }

    private void OnDestroy()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}
