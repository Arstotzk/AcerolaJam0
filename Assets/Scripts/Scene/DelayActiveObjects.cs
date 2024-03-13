using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayActiveObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> gameObjects;
    public float delay = 5f;
    void Start()
    {
        StartCoroutine(ActiveObjects(delay));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ActiveObjects(float time)
    {
        yield return new WaitForSeconds(time);

        foreach (var obj in gameObjects)
        {
            obj.SetActive(true);
        }
    }
}
