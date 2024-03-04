using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampIteract : MonoBehaviour
{
    // Start is called before the first frame update
    Lamp lamp;
    void Start()
    {
        lamp = GetComponentInParent<Lamp>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
