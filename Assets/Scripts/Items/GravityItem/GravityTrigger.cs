using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gravity TriggerEnter: " + other.gameObject.ToString());
        var tag = other.gameObject.tag;
        if (tag == "Item")
        {
            var gravity = other.gameObject.GetComponent<Gravity>();
            if (gravity != null)
                gravity.ReverseGravity();
        }
        else if (tag == "Player")
        {
            var playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
                playerMovement.ReverseGravity();
        }
        else if (tag == "Enemy")
        {
            var puppet = other.gameObject.GetComponent<Puppet>();
            if (puppet != null)
                puppet.ReverseGravity();
        }
    }
}
