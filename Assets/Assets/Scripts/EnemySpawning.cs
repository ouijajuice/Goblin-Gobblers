using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("Spawn Point Transforms")]
    public Transform[] spawnPoints;

    [Header("Enemy Prefabs")]
    public GameObject pawnPrefab;
    public GameObject rangedPrefab;
    public GameObject tankPrefab;

    [Header("Enemy Intervals")]
    public float pawnInterval;
    public float rangedInterval;
    public float tankInterval;

    //private float pawnIntervalDecrease = 0.1f;
    

    private void Start()
    {
        StartCoroutine(spawnEnemy(pawnInterval, pawnPrefab));

    }

    private void Update()
    {
        //pawnInterval -= pawnIntervalDecrease / Time.deltaTime;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemyPrefab)
    {
        yield return new WaitForSeconds(interval);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randomSpawnPointIndex]);
        StartCoroutine(spawnEnemy(interval, enemyPrefab));
    }

}
