using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Puppet puppet;
    public GameObject directionTrigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PuppetMove TriggerEnter: " + other.gameObject.ToString());
        if (other.tag == "Player")
        {
            puppet.StopDirection();
            puppet.isCanMove = true;
            directionTrigger.SetActive(false);
        }
    }
}
