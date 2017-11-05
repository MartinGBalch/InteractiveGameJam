using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public struct Item
{
    
    public int InventoryCount;
    public int MaxCount;
    public int InventoryItem;  //0 - RawMeat, 1 - CookedMeat, 2 - Herb ,3 - Sticks

   public void ClearSlot()
    {
        InventoryCount = 0;
        MaxCount = 0;
        InventoryItem = -1;
    }

    public void DefineItem()
    {
        if(InventoryItem == 1)
        {
            MaxCount = 1;
        }
        else
        {
            MaxCount = 3;
        }
    }
   
}
public class Backpack : MonoBehaviour {

    //public int rawMeat;
    //public int cookedMeat;
    public float healAmount;
    public float rawHungerRefil; // status effect on Eat
    public float rawInsanityDrain;
    public float rawHealthDrain;
    public float cookedInsanityRefill;
    public float cookedHungerRefill;
    public StatusManager manager;
    public GameObject campFire;
    public Text slot1;
    public Text slot2;
    public Text slot3;
    public Text slot4;

    public Image[] images;
    public Sprite[] imageSprites;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public ParticleSystem part;
    public ParticleSystem Fire;
    public ParticleSystem raw;
    public ParticleSystem cooked;
    //public int[] InventoryCount; // 0 is empty
    //public int[] InventoryItem; //  0 - RawMeat, 1 - CookedMeat, 2 - Herb, 3 - sticks 


    public bool getButton1()
    {
        return true;
    }
    public bool getButton2()
    {
        return true;
    }
    public bool getButton3()
    {
        return true;
    }
    public bool getButton4()
    {
        return true;
    }

    public void UpdateImages()
    {
        for(int i =0; i <4; i++)
        {
            if(items[i].InventoryItem == -1)
            {
                images[i].sprite = imageSprites[4];
            }
            else
            {
                images[i].sprite = imageSprites[items[i].InventoryItem];
            }
        }
    }

    public void useItem(int idx)
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            items[idx].ClearSlot();
            UpdateImages();
        }
        int itemType = items[idx].InventoryItem;
        if(itemType != -1)
        {
            
            switch (itemType)
            {
                case 0:
                    raw.Play();
                    items[idx].InventoryCount--;
                    isEmpty(idx);
                    manager.currentHunger += rawHungerRefil;
                    manager.currentHealth -= rawHealthDrain;
                    manager.currentInsanity -= rawHealthDrain;
                    UpdateImages();
                    break;
                case 1:
                    cooked.Play();
                    items[idx].InventoryCount--;
                    isEmpty(idx);
                    manager.currentHunger += cookedHungerRefill;
                    manager.currentInsanity += cookedInsanityRefill;
                    UpdateImages();
                    break;
                case 2:
                    part.Play();
                    items[idx].InventoryCount--;
                    isEmpty(idx);
                    manager.currentHealth += healAmount;
                    manager.currentHealth = Mathf.Clamp(manager.currentHealth, 0, manager.maxHealth);
                    UpdateImages();
                    break;
                case 3:
                    if(items[idx].InventoryCount == items[idx].MaxCount)
                    {
                        Fire.Play();
                        Vector3 spawnPos = transform.position + (transform.forward * 2);
                        Instantiate(campFire, spawnPos, campFire.transform.rotation);
                        items[idx].ClearSlot();
                        UpdateImages();
                    }
                    //spawn Fire
                    break;
            }
        }
        else
        {
            Debug.Log("Slot is Empty");
        }
        
    }

    void checkButton()
    {
        if(getButton1())
        {

        }
    }

    public Item[] items;


    public void isEmpty(int idx)
    {
        if(items[idx].InventoryCount <= 0)
        {
            items[idx].ClearSlot();
        }
        
    }

    public bool isFull()
    {
        int count = 0;
        for(int i =0; i < 4; i++)
        {
            if(items[i].InventoryCount > 0)
            {
                count++;
            }
        }
        return count == 4;
    }

    public int inventorySearch(int itemType)
    {
        for (int i = 0; i < 4; i++)
        {
            if (items[i].InventoryItem == itemType && items[i].InventoryCount > 0)
            {
                return i;
            }
        }
        return -1;
    }

    public int FindmatchingItemSlot(int itemType)
    {
        for (int i = 0; i < 4; i++)
        {
            if (items[i].InventoryItem == itemType && items[i].InventoryCount < items[i].MaxCount)
            {
                return i;
            }
        }
        return -1;
    }

    int FindEmptyInvetorySlot()
    {
        for(int i =0; i < 4; i++)
        {
            if(items[i].InventoryCount == 0)
            {
                return i;
            }
        }
        return -1; // invetory full
    }

    public bool PlaceItem(int itemType, int itemCount)
    {
        int idx = FindmatchingItemSlot(itemType);
        if(idx == -1)
        {
            idx = FindEmptyInvetorySlot();
            if (idx != -1)
            {
                
                items[idx].InventoryCount = itemCount;
                items[idx].InventoryItem = itemType;
                items[idx].DefineItem();
                return true;
            }
            else { Debug.Log("No matching Items, Inventory Full"); return false; }
        }
        else
        {
            
            items[idx].InventoryCount += itemCount;
            return true;
        }
       
    }

	// Use this for initialization
	void Start ()
    {
        
        items = new Item[4];
        for(int i =0; i < 4; i++)
        {
            items[i].ClearSlot();
        }
        manager = FindObjectOfType<StatusManager>();
        UpdateImages();
	}
	
	// Update is called once per frame
	void Update ()
    {
        slot1.text = "X" + items[0].InventoryCount.ToString();
        slot2.text = "X" + items[1].InventoryCount.ToString();
        slot3.text = "X" + items[2].InventoryCount.ToString();
        slot4.text = "X" + items[3].InventoryCount.ToString();
        //if (Input.GetMouseButtonDown(0) && rawMeat > 0)
        //{
        //    rawMeat--;
        //    manager.currentHunger += rawHungerRefil;
        //    manager.currentHealth -= rawHealthDrain;
        //    manager.currentInsanity -= rawHealthDrain;
        //}
        //if (Input.GetMouseButtonDown(1) && cookedMeat > 0)
        //{
        //    cookedMeat--;
        //    manager.currentHunger += cookedHungerRefill;
        //    manager.currentInsanity += cookedInsanityRefill;

        //}
       
    }
}
