using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Item
{
    // Start is called before the first frame update
    private LampIteract lampIteract;
    private Light light;

    override protected void Start()
    {
        base.Start();
        lampIteract = GetComponentInChildren<LampIteract>();
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void IteractionRightClickUp()
    {
        base.IteractionRightClickUp();
        lampIteract.GetComponent<Collider>().enabled = true;
    }
    public void Fire()
    {
        light.enabled = false;
    }
}
