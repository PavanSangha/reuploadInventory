using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableItem : ScriptableObject
{

    public string itemName;
    public StatToChange statTochange = new StatToChange();
    public int amountToChangeStat;
    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;


    public void UseItem()
    {
        if(statTochange == StatToChange.health)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().AddHealth(amountToChangeStat);

           
        }

        if (statTochange == StatToChange.shield)
        {
            GameObject.Find("Player").GetComponent<PlayerShield>().Addshield(amountToChangeStat);


        }
    }


    public enum StatToChange
    {
        none,
        health,
        shield,
    };


    public enum AttributeToChange
    {
        none,
        speed,
        jump,
    }
}
