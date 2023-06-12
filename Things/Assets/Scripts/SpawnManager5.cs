 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class SpawnManager5 : MonoBehaviour
 {
    public GameObject[] EnemiesPrefabs;
    private float StartDelay = 1;
    private float SpawnerTime = 10f;
     void Start()
    {
        InvokeRepeating("RandomEnemiesSpawner", StartDelay, SpawnerTime);
    }
     void Update()
    {

    }

    void RandomEnemiesSpawner()
    {
        {
        int EnemiesIndex = Random.Range(0, EnemiesPrefabs.Length);
        Vector3 spawnPo = new Vector3 (-43, 1, 43);
        Instantiate(EnemiesPrefabs[EnemiesIndex], spawnPo, EnemiesPrefabs[EnemiesIndex].transform.rotation);
        }
    }
 }