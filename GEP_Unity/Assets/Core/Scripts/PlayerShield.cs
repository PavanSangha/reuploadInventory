using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

    public int shield;
    public int maxshield = 10;
    // Start is called before the first frame update
    void Start()
    {
        shield = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addshield(int added)
    {
        shield += added;


    }
}
