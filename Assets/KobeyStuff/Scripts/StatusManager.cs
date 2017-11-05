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

    public float desiredHealth;
    public float desiredInsanity;
    public float desiredHunger;

    public int spriteState;
    public bool stateSwith1;
    public bool stateSwith2;
    public bool stateSwith3;

    // Use this for initialization
    void Start ()
    {
       
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentInsanity = maxInsanity;
	}

   void Lose()
    {
        Debug.Log("YOU LOSE FEGGET");
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
    float timer = .5f;
	
	// Update is called once per frame
	void Update ()
    {
        // Props = FindObjectsOfType<SpriteHandler>();

        timer -= Time.deltaTime;
        

        currentHunger -= hungerDrain * Time.deltaTime;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentInsanity = Mathf.Clamp(currentInsanity, 0, maxInsanity);
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);



        if (timer < 0)
        {
            hunger.fillAmount = currentHunger / maxHunger;
            health.fillAmount = currentHealth / maxHealth;
            instanity.fillAmount = currentInsanity / maxInsanity;
            timer = 0.5f;
        }

        if (currentHealth <= 0 || currentInsanity <= 0 || currentHunger <= 0)
        {
            hunger.fillAmount = currentHunger / maxHunger;
            health.fillAmount = currentHealth / maxHealth;
            instanity.fillAmount = currentInsanity / maxInsanity;
            Lose();
        }

    }
}
