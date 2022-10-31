using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0.1f,30f)] float spawnTimer = 1f;
    [SerializeField] [Range(0,50)] int poolSize = 5;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    } 

    void Start()
    {
        StartCoroutine(SpamEnemies());
    }

    private IEnumerator SpamEnemies() 
    {
        while (Application.isPlaying)
        {
            EnableObjectInPool();
            //Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i< pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i=0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
}
