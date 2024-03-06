using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public float healthDamage = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.TryGetComponent<PlayerHealth>(out var playerHealth)) 
        {
            playerHealth.health -= healthDamage;
        }
    }
}
