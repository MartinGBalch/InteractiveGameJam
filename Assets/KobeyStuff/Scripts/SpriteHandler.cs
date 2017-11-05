using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour {

    public Sprite[] mySprites;
    SpriteRenderer myRender;
    StatusManager manager;
    public float startTimer;
    float currentTimer;
	// Use this for initialization
	void Start ()
    {
        startTimer = Random.Range(5, 12);
        manager = FindObjectOfType<StatusManager>();
        myRender = GetComponent<SpriteRenderer>();
        myRender.sprite = mySprites[0];
	}
	

    public void UpdateSprite(int idx)
    {
        myRender.sprite = mySprites[idx];
    }

	// Update is called once per frame
	void Update ()
    {
        currentTimer -= Time.deltaTime;
        if(currentTimer < 0)
        {
            if (manager.currentInsanity < 30)
            {
                UpdateSprite(2);
            }
            else if (manager.currentHunger < 65)
            {

                UpdateSprite(3);
            }
            else if (manager.currentInsanity < 65)
            {

                UpdateSprite(1);
            }
            else if (manager.currentHunger < 30)
            {
                UpdateSprite(4);
            }
            else
            {
                UpdateSprite(0);
            }
            startTimer = Random.Range(5, 12);
            currentTimer = startTimer;
        }
        
    }
}
