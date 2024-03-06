using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostIteract : MonoBehaviour
{
    // Start is called before the first frame update
    public Ghost ghost;
    void Start()
    {
        ghost = GetComponentInParent<Ghost>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ghost.TurnOnColliders();
        }
        else if (other.gameObject.tag == "Item")
        {
            ghost.TurnOnColliders();
        }
    }
}
