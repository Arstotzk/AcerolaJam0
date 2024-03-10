using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> walkGrass;
    public List<AudioClip> runGrass;
    public List<AudioClip> jumpGrass;
    public List<AudioClip> landGrass;
    public bool isPlayWalk;
    public bool isPlayRun;
    public bool isPlayJump;
    public bool isPlayLand;
    public bool isOnAir = false;

    public float walkDelay = 0.5f;
    public float runDelay = 0.1f;
    public AudioSource move;

    private bool isMoveCoroutineStart = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!move.isPlaying && isPlayJump && !isOnAir)
        {
            move.clip = jumpGrass[Random.Range(0, jumpGrass.Count - 1)];
            move.Play();
            isOnAir = true;
        }
        else if (isPlayLand)
        {
            move.clip = landGrass[Random.Range(0, landGrass.Count - 1)];
            move.Play();
            isPlayLand = false;
            isOnAir = false;
        }
        else if (isPlayWalk && !move.isPlaying && !isMoveCoroutineStart && !isPlayRun && !isOnAir)
        {
            StartCoroutine(ChangeMoveSound(walkDelay, walkGrass[Random.Range(0, walkGrass.Count - 1)]));
        }
        else if (isPlayRun && !move.isPlaying && !isMoveCoroutineStart && !isOnAir)
        {
            StartCoroutine(ChangeMoveSound(runDelay, runGrass[Random.Range(0, runGrass.Count - 1)]));
        }
    }
    private IEnumerator ChangeMoveSound(float time, AudioClip clip)
    {
        isMoveCoroutineStart = true;
        yield return new WaitForSeconds(time);

        if (isPlayWalk == true && isPlayJump == false)
        {
            move.clip = clip;
            move.Play();
        }
        isMoveCoroutineStart = false;
    }


}
