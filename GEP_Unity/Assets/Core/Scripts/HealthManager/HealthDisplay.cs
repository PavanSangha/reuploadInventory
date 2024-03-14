using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxhealth;

    public Sprite emptyPotion;
    public Sprite fullpotion;
    public Image[] potions;

    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        health = playerHealth.health;
        maxhealth = playerHealth.maxHealth;

        for (int i = 0; i < potions.Length; i++) 
        {
            if(i < health)
            {
                potions[i].sprite = fullpotion;
            }
            else
            {
                potions[i].sprite = emptyPotion;
            }

            if(i< maxhealth)
            {
                potions[i].enabled = true;
            }
            else
            {
                potions[i].enabled = false;
            }
        }
    }
}
