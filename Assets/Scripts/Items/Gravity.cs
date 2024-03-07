using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isReverseGravity;
    public Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(isReverseGravity)
            rigidbody.AddForce(-Physics.gravity * rigidbody.mass * 2);
    }
    public void ReverseGravity()
    {
        isReverseGravity = !isReverseGravity;
    }
}
