using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private float time = 1.5f;


    public GameObject[] enemies;
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());    
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = transform.position;
        //spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
