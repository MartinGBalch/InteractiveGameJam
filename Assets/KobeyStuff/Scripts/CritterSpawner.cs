﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterSpawner : MonoBehaviour {


    public int maxCrittersInGame;
    public int currentCrittersInGame;
    List<GameObject> critterPool;
    public GameObject critter;
    public float SpawnInterval;
    private float currentInterval;


    // Use this for initialization
    void Start () {
        critter.GetComponent<CritterWander>().spawn = this;
        critterPool = new List<GameObject>();
        currentInterval = SpawnInterval;
        currentCrittersInGame = 0;
        for(int i =0; i <maxCrittersInGame; i++)
        {
            var babe = Instantiate(critter);
            babe.SetActive(false);
            critterPool.Add(babe);
        }
		
	}
	
    void SpawnCritter()
    {
        for (int i = 0; i < maxCrittersInGame; i++)
        {
            if (!critterPool[i].activeInHierarchy)
            {
                critterPool[i].SetActive(true);
                critterPool[i].transform.position = transform.position;
                currentCrittersInGame++;
                break;
            }
        }
        currentInterval = SpawnInterval;
    }
	// Update is called once per frame
	void Update ()
    {
	    if(currentCrittersInGame < maxCrittersInGame)
        {
            currentInterval -= Time.deltaTime;
            if(currentInterval < 0)
            {
                SpawnCritter();
            }
        }
	}
}