using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject player;
    public float spawnInterval = 2f;
    public float spawnRadius = 8f;

    private float timer;
    void Update()
    {
        if (player == null) return;
        PlayerScript ps = player.GetComponent<PlayerScript>();
        if (ps == null || ps.health <= 0) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPos = player.transform.position + (Vector3)randomDir;

        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
        EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
        enemyScript.player = player;
        
        int playerLevel = player.GetComponent<PlayerScript>().level;

        int health = (int)(enemyScript.health * ((0.1 * playerLevel) + 1));
        float speed = (float)(enemyScript.speed * ((0.1 * playerLevel) + 1));
        float droppedXp = (float)(enemyScript.droppedXP * ((0.25 * playerLevel) + 1));
        
        enemyScript.health =  health;
        enemyScript.speed = speed;
        enemyScript.droppedXP = droppedXp;

    }
}