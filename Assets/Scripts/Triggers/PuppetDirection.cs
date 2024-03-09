using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetDirection : MonoBehaviour
{
    // Start is called before the first frame update
    public Puppet puppet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PuppetDirection TriggerEnter: " + other.gameObject.ToString());
        if (other.tag == "Player")
        {
            puppet.PlayDirection();
        }
    }
}
