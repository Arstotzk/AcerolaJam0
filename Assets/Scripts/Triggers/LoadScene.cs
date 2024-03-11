using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    private AsyncOperation asyncOperation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            asyncOperation.allowSceneActivation = true;
        }
    }

    private IEnumerator LoadSceneAsyncProcess(string sceneName)
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            Debug.Log($"[scene]:{sceneName} [load progress]: {asyncOperation.progress}");

            yield return null;
        }
    }

    public void LoadSceneAsync() 
    {
        StartCoroutine(LoadSceneAsyncProcess(sceneName));
        GetComponent<SaveLoadInventory>().Save();
    }
}
