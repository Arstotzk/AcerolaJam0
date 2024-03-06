using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public float mindDamage = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.TryGetComponent<PlayerMind>(out var playerMind))
        {
            playerMind.mind -= mindDamage;
        }
    }
}