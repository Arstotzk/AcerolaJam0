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

    public List<AudioClip> walkRock;
    public List<AudioClip> runRock;
    public List<AudioClip> jumpRock;
    public List<AudioClip> landRock;

    public List<AudioClip> walkWood;
    public List<AudioClip> runWood;
    public List<AudioClip> jumpWood;
    public List<AudioClip> landWood;

    public AudioClip fear;

    public bool isPlayWalk;
    public bool isPlayRun;
    public bool isPlayJump;
    public bool isPlayLand;
    public bool isOnAir = false;
    public bool onGrass;
    public bool onRock;
    public bool onWood;

    public bool isFear;

    public float walkDelay = 0.5f;
    public float runDelay = 0.1f;
    public AudioSource move;
    public AudioSource fearSource;

    private bool isMoveCoroutineStart = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!move.isPlaying && isPlayJump && !isOnAir)
        {
            move.clip = GetJumpClip();
            move.Play();
            isOnAir = true;
        }
        else if (isPlayLand)
        {
            move.clip = GetLandClip();
            move.Play();
            isPlayLand = false;
            isOnAir = false;
        }
        else if (isPlayWalk && !move.isPlaying && !isMoveCoroutineStart && !isPlayRun && !isOnAir)
        {
            StartCoroutine(ChangeMoveSound(walkDelay, GetWalkClip()));
        }
        else if (isPlayRun && !move.isPlaying && !isMoveCoroutineStart && !isOnAir)
        {
            StartCoroutine(ChangeMoveSound(runDelay, GetRunClip()));
        }

        if (isFear && !fearSource.isPlaying)
        {
            fearSource.clip = fear;
            fearSource.Play();
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

    public AudioClip GetWalkClip()
    {
        if (onGrass)
            return walkGrass[Random.Range(0, walkGrass.Count - 1)];
        else if (onRock)
            return walkRock[Random.Range(0, walkRock.Count - 1)];
        else if (onWood)
            return walkWood[Random.Range(0, walkWood.Count - 1)];

        return walkRock[Random.Range(0, walkRock.Count - 1)];
    }

    public AudioClip GetRunClip()
    {
        if (onGrass)
            return runGrass[Random.Range(0, runGrass.Count - 1)];
        else if (onRock)
            return runRock[Random.Range(0, runRock.Count - 1)];
        else if (onWood)
            return runWood[Random.Range(0, runWood.Count - 1)];

        return runRock[Random.Range(0, runRock.Count - 1)];
    }

    public AudioClip GetJumpClip()
    {
        if (onGrass)
            return jumpGrass[Random.Range(0, jumpGrass.Count - 1)];
        else if (onRock)
            return jumpRock[Random.Range(0, jumpRock.Count - 1)];
        else if (onWood)
            return jumpWood[Random.Range(0, jumpWood.Count - 1)];

        return jumpRock[Random.Range(0, jumpRock.Count - 1)];
    }

    public AudioClip GetLandClip()
    {
        if (onGrass)
            return landGrass[Random.Range(0, landGrass.Count - 1)];
        else if (onRock)
            return landRock[Random.Range(0, landRock.Count - 1)];
        else if (onWood)
            return landWood[Random.Range(0, landWood.Count - 1)];

        return landRock[Random.Range(0, landRock.Count - 1)];
    }


}
