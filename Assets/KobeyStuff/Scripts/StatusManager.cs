using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusManager : MonoBehaviour {

    public float maxHealth;
    public float maxInsanity;
    public float maxHunger;
    public SpriteHandler[] Props;
    public Image health;
    public Image instanity;
    public Image hunger;

    public float hungerDrain;
    //Create a list of all ICorruptable Objects
    // Call update Material on all of them

    //[HideInInspector]
    public float currentHealth;
    public float currentInsanity;
    public float currentHunger;


    public int spriteState;
    public bool stateSwith1;
    public bool stateSwith2;
    public bool stateSwith3;

    // Use this for initialization
    void Start ()
    {
        Props = FindObjectsOfType<SpriteHandler>();
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentInsanity = maxInsanity;
	}

   

    void UpdateSprites(int idx)
    {
        for(int i =0; i < Props.Length; i++)
        {
            Props[i].GetComponent<ICorruptable>().UpdateSprite(idx);
        }
    }

    void OnDrugs()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(currentInsanity < 30)
        {
            UpdateSprites(2);
        }
        else if(currentInsanity < 65)
        {
           
            UpdateSprites(1);
        }
        else
        {
            UpdateSprites(0);
        }        


        currentHunger -= hungerDrain * Time.deltaTime;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentInsanity = Mathf.Clamp(currentInsanity, 0, maxInsanity);
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

        health.fillAmount = currentHealth / maxHealth;
        instanity.fillAmount = currentInsanity / maxInsanity;
        hunger.fillAmount = currentHunger / maxHunger;

        

    }
}
