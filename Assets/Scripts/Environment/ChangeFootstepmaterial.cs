using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFootstepmaterial : MonoBehaviour
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
            other.GetComponent<PlayerSounds>().onWood = true;
            other.GetComponent<PlayerSounds>().onGrass = false;
            other.GetComponent<PlayerSounds>().onRock = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerSounds>().onWood = false;
            other.GetComponent<PlayerSounds>().onGrass = true;
            other.GetComponent<PlayerSounds>().onRock = false;
        }
    }
}
