using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject sign;
    public GameObject[] enemys;

    public float[] spawnTime;
    public float signDisplayTime = 2f;

    void Start()
    {
        spawnTime[0] = 1f;
        spawnTime[1] = 2f;
        StartCoroutine(enemySpawnerNum(spawnTime[0], enemys[0]));
        StartCoroutine(enemySpawnerNum(spawnTime[1], enemys[1]));
    }

     private IEnumerator enemySpawnerNum(float seconds, GameObject enemy)
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10.5f, 10.5f), Random.Range(-6f, 6f), 0);
            GameObject signInstance = Instantiate(sign, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(signDisplayTime);
            Destroy(signInstance);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(seconds);
        }
    }

}
