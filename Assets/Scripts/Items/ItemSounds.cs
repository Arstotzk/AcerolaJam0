using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip hitClip;
    public AudioSource hitSource;
    public AudioClip activateClip;
    public AudioSource activateSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHit()
    {
        hitSource.clip = hitClip;
        hitSource.Play();
    }
    public void PlayActivate()
    {
        activateSource.clip = activateClip;
        activateSource.Play();
    }
}
