using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public void RestartSceneOn()
    {
        StartCoroutine(RestartCurrentScene(2f));
    }
    private IEnumerator RestartCurrentScene(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
