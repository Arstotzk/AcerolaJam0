using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEffect : MonoBehaviour
{
    public GameObject parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pQuat = parent.transform.rotation;
        transform.rotation = Quaternion.Euler(-pQuat.x, -pQuat.y, -pQuat.z);
    }
}
