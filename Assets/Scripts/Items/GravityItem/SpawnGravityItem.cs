using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGravityItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject copyObject;
    public GameObject spawnPoint;

    public float spawnTime = 5f;
    public AudioSource audioSource;
    public bool isSpawnStart = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInChildren<Item>() == null && !isSpawnStart)
        {
            StartCoroutine(SpawnGravity(spawnTime));
        }
    }

    private IEnumerator SpawnGravity(float time)
    {
        isSpawnStart = true;
        yield return new WaitForSeconds(time);

        audioSource.Play();
        var copy = GameObject.Instantiate(copyObject);
        copy.transform.parent = this.transform;
        copy.transform.position = spawnPoint.transform.position;
        isSpawnStart = false;
    }
}
