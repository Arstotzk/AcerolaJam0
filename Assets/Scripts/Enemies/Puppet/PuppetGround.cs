using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetGround : MonoBehaviour
{
    // Start is called before the first frame update
    public Puppet puppet;
    void Start()
    {
        puppet = GetComponentInParent<Puppet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PuppetGround TriggerEnter: " + other.gameObject.ToString());
        if (other.gameObject.tag == "Ground")
        {
            puppet.SetOnGround();
        }
    }
}
