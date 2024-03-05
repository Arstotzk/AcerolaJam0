using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LampFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire;
    public GameObject ground;
    private bool fireStarted = false;
    public Collider phisCollider;
    void Start()
    {
        ground = GameObject.FindGameObjectsWithTag("MainGround").FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FireStart()
    {
        Start();
        fire.SetActive(true);
        fireStarted = true;
        phisCollider.enabled = true;
        transform.parent = ground.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fire: " + other.name + other.gameObject.tag);
        if (!fireStarted)
            return;

        Debug.Log("Fire: " + other.name + other.gameObject.tag);
        var tag = other.gameObject.tag;
        if (tag == "Enemy")
        {
            Puppet puppet;
            if (other.gameObject.TryGetComponent<Puppet>(out puppet))
            {
                puppet.Death();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!fireStarted)
            return;

        var tag = other.gameObject.tag;
        if (tag == "Player")
        {
            var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.health -= 2f;
        }
    }
}
