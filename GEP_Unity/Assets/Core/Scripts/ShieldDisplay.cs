using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public int shield;
    public int MaxShield;

    public Sprite emptyPotion;
    public Sprite fullpotion;
    public Image[] potions;

    public PlayerShield playerShield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        shield = playerShield.shield;
        MaxShield = playerShield.maxshield;

        for (int i = 0; i < potions.Length; i++)
        {
            if (i < shield)
            {
                potions[i].sprite = fullpotion;
            }
            else
            {
                potions[i].sprite = emptyPotion;
            }

            if (i < MaxShield)
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
