using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampIteract : MonoBehaviour
{
    Lamp lamp;
    void Start()
    {
        lamp = GetComponentInParent<Lamp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Ground" || tag == "Wall" || tag == "Enemy")
        {
            lamp.Fire();
        }
    }
}
