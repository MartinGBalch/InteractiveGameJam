using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbSpawn : MonoBehaviour {
    public int maxHerbsInGame;
    public int currentHerbsInGame;
    List<GameObject> herbPool;
    public GameObject goodHerb;
    public GameObject badHerb;
    public float spawnInterval;
    public float currentInterval;
    public float range;
	// Use this for initialization
	void Start ()
    {
        currentInterval = spawnInterval;
        herbPool = new List<GameObject>();
        for(int i =0; i < maxHerbsInGame; i++)
        {
            if(i % 2 == 0)
            {
                var babe = Instantiate(goodHerb);
                babe.GetComponent<Herb>().spawn = this;
                babe.SetActive(false);
                herbPool.Add(babe);
            }
            else
            {
                var babe = Instantiate(badHerb);
                babe.GetComponent<TrippyHerb>().spawn = this;
                babe.SetActive(false);
                herbPool.Add(babe);
            }
        }
        for(int i =0; i < maxHerbsInGame; i++)
        {
            SpawnHerb();
        }
	}
	
    void SpawnHerb()
    {
        
        
            for(int i =0; i < maxHerbsInGame; i++)
            {
                if(!herbPool[i].activeInHierarchy)
                {
                    herbPool[i].SetActive(true);
                    float x = Random.Range(-range, range);
                    float z = Random.Range(-range, range);
                    herbPool[i].transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
                    currentHerbsInGame++;
                    break;
                }
               
            }
        currentInterval = spawnInterval;
    }

	// Update is called once per frame
	void Update ()
    {
        if (currentHerbsInGame < maxHerbsInGame)
        {
            currentInterval -= Time.deltaTime;
            if(currentInterval < 0)
            {
                SpawnHerb();
            }
        }

    }
}
