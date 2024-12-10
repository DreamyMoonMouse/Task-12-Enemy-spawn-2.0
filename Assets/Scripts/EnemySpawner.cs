using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;

    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemies());
    }
    
    private void OnDestroy()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }
        }

    private IEnumerator SpawnEnemies()
    {
        bool isRunning = true;
        
        while (isRunning)
        {
            yield return new WaitForSeconds(_spawnInterval);
            
            if (_spawnPoints.Length > 0)
            {
                int randomIndex = Random.Range(0, _spawnPoints.Length);
                _spawnPoints[randomIndex].Spawn();
            }
        }
    }
}
