using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int enemyCount;

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private Stack<GameObject> enemyPool = new Stack<GameObject>();

    private List<int> spawnedPoints = new List<int>();
    private int columnCount;
    private int randomEnemy;
    private int randomSpawnPoint;
    private GameObject enemy;

    void Start()
    {
        StartCoroutine(SpawnEnemyWave());

        InvokeRepeating("CheckPool", 0, 0.05f);
    }

    public IEnumerator SpawnEnemyWave()
    {
        columnCount = Random.Range(1, 6);

        yield return new WaitForSeconds(5f);

        if (enemyCount <= columnCount)
        {
            columnCount = enemyCount;

            for (int i = 0; i < columnCount; i++)
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                while (spawnedPoints.Contains(randomSpawnPoint))
                {
                    randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                }
                spawnedPoints.Add(randomSpawnPoint);
                enemy = enemyPool.Pop();
                enemy.transform.position = spawnPoints[randomSpawnPoint].position;
                enemy.SetActive(true);
            }
            spawnedPoints.Clear();
            enemyCount = 0;
        }
        else
        {
            enemyCount -= columnCount;

            for (int i = 0; i < columnCount; i++)
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                while (spawnedPoints.Contains(randomSpawnPoint))
                {
                    randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                }
                spawnedPoints.Add(randomSpawnPoint);
                enemy = enemyPool.Pop();
                enemy.transform.position = spawnPoints[randomSpawnPoint].position;
                enemy.SetActive(true);
            }
            spawnedPoints.Clear();
            yield return new WaitForSeconds(3f);
            StartCoroutine(SpawnEnemyWave());
        }
    }

    private void CheckPool()
    {
        if (enemyPool.Count < 100)
        {
            randomEnemy = Random.Range(0, enemyPrefabs.Length);
            enemy = Instantiate(enemyPrefabs[randomEnemy], transform);

            enemy.SetActive(false);
            enemyPool.Push(enemy);
        }
    }
}
