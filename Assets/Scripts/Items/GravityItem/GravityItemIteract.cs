using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityItemIteract : MonoBehaviour
{
    // Start is called before the first frame update
    GravityItem gravityItem;
    void Start()
    {
        gravityItem = GetComponentInParent<GravityItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GravityItem TriggerEnter: " + other.gameObject.ToString());
        var tag = other.gameObject.tag;
        if (tag == "Item" || tag == "Wall" || tag == "Enemy" || tag == "Ground")
        {
            if(gravityItem.gameObject != other.gameObject)
                gravityItem.ChangeGravity();
        }
    }
}
