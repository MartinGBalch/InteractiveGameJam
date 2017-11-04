using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour, ICorruptable {

    public Sprite[] mySprites;
    SpriteRenderer myRender;

	// Use this for initialization
	void Start ()
    {

        myRender = GetComponent<SpriteRenderer>();
        myRender.sprite = mySprites[0];
	}
	

    public void UpdateSprite(int idx)
    {
        myRender.sprite = mySprites[idx];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
