using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour {

    public Sprite[] mySprites;
    SpriteRenderer myRender;
    StatusManager manager;
	// Use this for initialization
	void Start ()
    {
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
        if (manager.currentInsanity < 30)
        {
            UpdateSprite(2);
        }
        else if (manager.currentInsanity < 65)
        {

            UpdateSprite(1);
        }
        else
        {
            UpdateSprite(0);
        }
    }
}
