using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Item
{
    // Start is called before the first frame update
    private LampIteract lampIteract;
    private Light light;
    private bool fireStarted = false;
    public float continuedTime;
    private float startTime;
    public GameObject lampFire;
    private bool isAlreadyFired = false;

    override protected void Start()
    {
        base.Start();
        lampIteract = GetComponentInChildren<LampIteract>();
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireStarted && startTime + continuedTime < Time.time)
        {
            fireStarted = false;
            lampFire.SetActive(false);
        }
    }

    public override void IteractionRightClickUp()
    {
        base.IteractionRightClickUp();
        lampIteract.GetComponent<Collider>().enabled = true;
    }
    public void Fire()
    {
        if (isAlreadyFired)
            return;
        light.enabled = false;
        lampFire.SetActive(true);
        lampFire.GetComponent<LampFire>().FireStart();
        startTime = Time.time;
        fireStarted = true;
        isAlreadyFired = true;
    }
}
