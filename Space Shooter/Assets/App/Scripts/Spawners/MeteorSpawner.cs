using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int meteorCount;

    private Stack<GameObject> meteorPool = new Stack<GameObject>();

    private GameObject meteorReserve;
    private GameObject meteor;

    void Start()
    {
        StartCoroutine(SpawnMeteorWave());

        InvokeRepeating("CheckPool", 0, 0.05f);
    }

    public IEnumerator SpawnMeteorWave()
    {
        yield return new WaitForSeconds(5f);
        meteor = meteorPool.Pop();
        meteor.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        meteor.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(meteor);
        StartCoroutine(SpawnMeteorWave());
    }

    private void CheckPool()
    {
        if (meteorPool.Count < 100)
        {
            meteorReserve = Instantiate(meteorPrefabs[Random.Range(0, meteorPrefabs.Length)], transform);

            meteorReserve.SetActive(false);
            meteorPool.Push(meteorReserve);
        }
    }
}
