using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Collider itemCollider;
    public Collider triggerCollider;
    public Vector3 positionOnPick;
    public Vector3 rotate;
    void Start()
    {

    }

    void Update()
    {

    }

    public void PickUp()
    {
        itemCollider.enabled = false;
        triggerCollider.enabled = false;
    }
}
