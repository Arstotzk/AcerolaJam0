using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;

public class PlayerMind : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        mind += 2f;
        volume.weight = 1 - (mind / 100); 
    }
}
