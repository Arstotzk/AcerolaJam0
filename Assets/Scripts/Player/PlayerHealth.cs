using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float _health;
    public float health
    {
        get => _health;
        set
        {
            if (value < 0)
            {
                _health = 0;
            }
            else if (value > 100)
            {
                _health = 100;
            }
            else
            {
                _health = value;
            }

            if (value < 50)
            {
                GetComponent<PlayerSounds>().isLowHealth = true;
            }
            else
            {
                GetComponent<PlayerSounds>().isLowHealth = false;
            }
        }
    }

    private PlayerMovement playerMovement;
    public void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void FixedUpdate()
    {
        health += 0.2f;
        playerMovement.SetDebufSpeed(1 - health/100);
    }
}
