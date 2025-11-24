using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void LoadSceneWithDelayButton(string sceneName)
    {
        Debug.Log($"[UI] Click -> {sceneName}");
        StartCoroutine(LoadAfterDelay(sceneName, 1f));
    }

    private IEnumerator LoadAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
