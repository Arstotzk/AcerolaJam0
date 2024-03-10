using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightIteract : MonoBehaviour
{
    // Start is called before the first frame update
    private Flashlight flashlight;
    void Start()
    {
        flashlight = GetComponentInParent<Flashlight>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Flashlight TriggerEnter:" + other.gameObject.ToString());
        if (other.tag == "Ground")
        {
            flashlight.TurnLight();
        }

    }
}
