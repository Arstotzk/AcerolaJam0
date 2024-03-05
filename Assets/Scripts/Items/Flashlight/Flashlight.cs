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
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CollisionEnter: " + collision.gameObject.ToString());
        TurnLight();
    }
    public void TurnLight() 
    {
        light.enabled = !light.enabled;
    }
}
