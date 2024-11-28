using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a generar
    public float spawnDelay = 1f; // Tiempo antes del primer spawn
    public float spawnInterval = 4f; // Intervalo entre spawns

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnInterval);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

}
