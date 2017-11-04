using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    StatusManager manager;
    public int maxEnemiesInGame;
    public int currentEnemiesInGame;
    List<GameObject> enemyPool;
    public GameObject Enemy;
    public float SpawnInterval;
    private float currentInterval;
	// Use this for initialization
	void Start ()
    {
        currentInterval = SpawnInterval;
        enemyPool = new List<GameObject>();
        for(int i =0; i < maxEnemiesInGame; i++)
        {
            var baby = Instantiate(Enemy);
            baby.SetActive(false);
            enemyPool.Add(baby);
        }
        manager = FindObjectOfType<StatusManager>();
	}
	

    void SpawnEnemy()
    {
        if(currentEnemiesInGame < maxEnemiesInGame)
        {
            for (int i = 0; i < maxEnemiesInGame; i++)
            {
                if (!enemyPool[i].activeInHierarchy)
                {
                    enemyPool[i].SetActive(true);
                    enemyPool[i].transform.position = transform.position;
                    currentEnemiesInGame++;
                    break;
                }
            }
        }
        currentInterval = SpawnInterval;
    }

    void DeSpawnEnemy()
    {
        for (int i = 0; i < maxEnemiesInGame; i++)
        {
            if (enemyPool[i].activeInHierarchy)
            {
                enemyPool[i].SetActive(false);
              
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (manager.currentInsanity < 75)
        {
            currentInterval -= Time.deltaTime;
            if (currentInterval < 0)
            {
                SpawnEnemy();
            }
        }
        else
        {
            DeSpawnEnemy();
        }
       
	}
}
