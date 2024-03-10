using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Item
{
    Light light;
    override protected void Start()
    {
        base.Start();
        light = GetComponentInChildren<Light>();
    }
    void Update()
    {
        
    }
    public override void IteractionLeftClickDown()
    {
        TurnLight();
    }

    public void TurnLight() 
    {
        light.enabled = !light.enabled;
        GetComponent<ItemSounds>().PlayActivate();
    }
}
