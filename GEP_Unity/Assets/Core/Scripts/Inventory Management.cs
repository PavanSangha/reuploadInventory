using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{

    
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlots[] itemSlots;
    public ScriptableItem[] scriptableItems;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DeselectAllSlots()
    {
        for(int i = 0;i < itemSlots.Length;i++)
        {
            itemSlots[i].selectedShade.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
   public void UseItem(string itemName)
    {
        for (int i = 0; i < scriptableItems.Length; i++)
        {
            if (scriptableItems[i].itemName == itemName)
            {
                scriptableItems[i] . UseItem();
            }
        }
    }
    public int AddItem (string itemName, int Amount, Sprite itemSprite, string itemDiscription)
    {
       for (int i = 0; i < itemSlots.Length; i++) 
        { 
        if (itemSlots[i].full == false && itemSlots[i].itemName == itemName || itemSlots[i].amount == 0)
            {
                
                int leftOverItems = itemSlots[i].AddItem(itemName, Amount, itemSprite,itemDiscription);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName,leftOverItems, itemSprite, itemDiscription);

                return leftOverItems;
            }

        }
        return Amount;
    }

}
