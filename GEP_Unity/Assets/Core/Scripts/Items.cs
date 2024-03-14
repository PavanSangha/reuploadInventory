using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    public string Itemnames;

    [SerializeField]
    public int Amount;

    [SerializeField]
    public Sprite sprite;

 
    [SerializeField]
    public string itemDescription;
   [TextArea]

    private InventoryManagement inventoryManagement;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManagement = GameObject.Find("Inventory Canvas").GetComponent<InventoryManagement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManagement.AddItem(Itemnames, Amount, sprite, itemDescription);
            if (leftOverItems <= 0)
            Destroy(gameObject);

            else 
                Amount = leftOverItems;
        }
    }
}
