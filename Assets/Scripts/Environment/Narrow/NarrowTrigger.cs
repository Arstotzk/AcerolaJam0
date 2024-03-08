using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrowTrigger : MonoBehaviour
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
        if (other.tag == "Player")
        {
            var playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
                playerMovement.isNarrow = true;
            var playerNarrow = other.gameObject.GetComponent<PlayerNarrow>();
            if (playerNarrow != null)
                playerNarrow.isNarrow = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("NarrowTrigger OnTriggerStay: " + other.gameObject.ToString());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            var playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
                playerMovement.isNarrow = false;
            var playerNarrow = other.gameObject.GetComponent<PlayerNarrow>();
            if (playerNarrow != null)
                playerNarrow.isNarrow = false;
        }
    }
}
