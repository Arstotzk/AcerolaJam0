using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnemyOpen : MonoBehaviour
{
    private Door door;
    void Start()
    {
        door = GetComponentInParent<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Door TriggerEnter: " + other.gameObject.ToString());
        if (other.gameObject.tag == "Enemy" && !door.isOpen)
        {
            door.Action();
        }
    }
}
