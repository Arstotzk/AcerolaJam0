using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource closeSource;
    public AudioSource openSource;
    public AudioSource tryOpenSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClose()
    {
        closeSource.Play();
    }
    public void PlayOpen()
    {
        openSource.Play();
    }
    public void PlayTryOpen()
    {
        tryOpenSource.Play();
    }
}
