using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;

public class PlayerMind : MonoBehaviour
{
    [SerializeField]
    private float _mind;
    public float mind {
        get => _mind;
        set 
        {
            if (value < 0)
            {
                _mind = 0;
            }
            else if (value > 100)
            {
                _mind = 100;
            }
            else 
            {
                _mind = value;
            }
        } 
    }

    public Volume volume;
    void Start()
    {
        volume = GameObject.FindGameObjectsWithTag("VolumeChromatic").FirstOrDefault().GetComponent<Volume>();
    }

    void FixedUpdate()
    {
        mind += 0.3f;
        volume.weight = 1 - (mind / 100); 
    }
}
