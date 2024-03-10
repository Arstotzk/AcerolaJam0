using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> moveClips;
    public AudioSource audioSource;
    public bool isMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove && !audioSource.isPlaying) 
        {
            audioSource.clip = GetMoveClip();
            audioSource.Play();
        }
    }

    public AudioClip GetMoveClip()
    {
        return moveClips[Random.Range(0, moveClips.Count - 1)];
    }
}
