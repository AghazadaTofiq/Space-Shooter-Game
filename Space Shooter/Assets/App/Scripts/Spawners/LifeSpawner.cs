using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] lifePrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int lifeCount;

    private Stack<GameObject> lifePool = new Stack<GameObject>();

    private GameObject life;
    private GameObject lifeReserve;

    void Start()
    {
        StartCoroutine(SpawnLifeWave());

        InvokeRepeating("CheckPool", 0, 0.05f);
    }

    public IEnumerator SpawnLifeWave()
    {
        yield return new WaitForSeconds(7f);
        life = lifePool.Pop();
        life.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        life.SetActive(true);
        yield return new WaitForSeconds(7f);
        Destroy(life);
        StartCoroutine(SpawnLifeWave());
    }

    private void CheckPool()
    {
        if (lifePool.Count < 100)
        {
            lifeReserve = Instantiate(lifePrefabs[Random.Range(0, lifePrefabs.Length)], transform);

            lifeReserve.SetActive(false);
            lifePool.Push(lifeReserve);
        }
    }
}
