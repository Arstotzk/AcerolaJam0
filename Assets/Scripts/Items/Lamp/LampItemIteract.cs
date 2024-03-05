using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampItemIteract : MonoBehaviour
{
    Lamp lamp;
    void Start()
    {
        lamp = GetComponentInParent<Lamp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Item")
        {
            if (other.gameObject != lamp)
                lamp.Fire();
        }
    }
}
