using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("Spawn Point Transforms")]
    [SerializeField]
    private Transform rowOne;
    private Transform rowTwo;
    private Transform rowThree;

    [Header ("Enemy Prefabs")]
    [SerializeField]
    private GameObject pawnPrefab;
    private GameObject rangedPrefab;
    private GameObject tankPrefab;

    [Header ("Enemy Intervals")]
    [SerializeField]
    private float pawnInterval;
    private float rangedInterval;
    private float tankInterval;



    private void Start()
    {
        StartCoroutine(spawnEnemy(pawnInterval, pawnPrefab));
      

    }

    private void Update()
    {
        

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemyPrefab)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemyPrefab, rowOne);
        StartCoroutine(spawnEnemy(interval, newEnemy));
    }

}
