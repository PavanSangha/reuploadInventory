using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;

public class ItemSlots : MonoBehaviour, IPointerClickHandler
{
    public bool full;
    public string itemName;
    public int amount;
    public Sprite itemSprite;
    public string itemDescription;
    public Sprite Nosprite;



    [SerializeField]
    private TMP_Text amountText;

    [SerializeField]
    private Image itemImage;


    [SerializeField]
    private int maxNumOfItems;



    public Image IDImage;
    public TMP_Text IDNameText;
    public TMP_Text IDText;



    public GameObject selectedShade;
    public bool thisItemSelected;


    private InventoryManagement inventoryManagement;
    private void Start()
    {
        inventoryManagement = GameObject.Find("Inventory Canvas").GetComponent<InventoryManagement>();
    }
    public int AddItem(string itemName, int Amount, Sprite itemSprite,string itemDiscription)
    {
        if (full)
            return amount;

  
        this.itemName = itemName;
        itemImage.sprite = itemSprite;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDiscription;
        this.amount += Amount;
        if (this.amount >= maxNumOfItems)
        {

            amountText.text = maxNumOfItems.ToString();
            amountText.enabled = true;
            full = true;

            int moreItems = this.amount - maxNumOfItems;
            this.amount = maxNumOfItems;
            return moreItems;
        }

        amountText.text = this.amount.ToString();
        amountText.enabled = true;
        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       if(eventData.button == PointerEventData.InputButton.Left)
        {
          OnLeftClick ();
        }
       if (eventData.button == PointerEventData.InputButton.Right) 
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            inventoryManagement.UseItem(itemName);

            this.amount -= 1;
            amountText.text = this.amount.ToString();


            if (this.amount <= 0)
                emptyslot();
        }
        else
        {
        inventoryManagement.DeselectAllSlots();
        selectedShade.SetActive(true);
        thisItemSelected = true;
        IDNameText.text = itemName;
        IDText.text = itemDescription;
        IDImage.sprite = itemSprite;

        if( IDImage.sprite == null) 
            IDImage.sprite = Nosprite;

        }
    
    } 
    private void emptyslot()
    {
        amountText.enabled=false;
        itemImage.sprite = Nosprite;
        IDNameText.text = "";
        IDText.text = "";
        IDImage.sprite = Nosprite;

    }

  public void OnRightClick()
    {
        GameObject itemDrop = new GameObject(itemName);
        Items newItem = itemDrop.AddComponent<Items>();
        newItem.Amount = 1;
        newItem.Itemnames = itemName;
        newItem.sprite = itemSprite;
        newItem.itemDescription = itemDescription;

        SpriteRenderer sr = itemDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;
        sr.sortingLayerName  = "Ground";

        itemDrop.AddComponent<BoxCollider>();
        itemDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1.5f,0.5f,0);
        itemDrop.transform.localScale = new Vector3(.1f,.1f,.1f);
        this.amount -= 1;
        amountText.text = this.amount.ToString();


        if (this.amount <= 0)
            emptyslot();
    }

 
  


    // Update is called once per frame
    void Update()
    {
         
    }
}
