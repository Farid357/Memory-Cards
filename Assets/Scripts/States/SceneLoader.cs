using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour
{
    public void StartLoad(int sceneIndex)
    {
        StartCoroutine(Load(sceneIndex));
    }
    private IEnumerator Load(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
