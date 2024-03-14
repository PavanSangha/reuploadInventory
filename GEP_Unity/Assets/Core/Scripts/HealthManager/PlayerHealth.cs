using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth = 10;



    
    // Start is called before the first frame update
    void Start()
    {
        health = 0;
    }

    // Update is called once per frame
 

    public void AddHealth(int added)
    {
        health += added;

        
    }
}
