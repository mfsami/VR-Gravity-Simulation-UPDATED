using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown destinationDropdown;
    [SerializeField] private string[] sceneNames;

    public SceneFader screenfade;

    public void TravelToSelectedDestination()
    {
        int index = destinationDropdown.value;

        if (index < 0 || index >= sceneNames.Length)
        {
            Debug.LogWarning("TravelMenu: No scene mapped for dropdown index " + index);
            return;
        }

        string sceneName = sceneNames[index];
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("TravelMenu: Empty scene name for index " + index);
            return;
        }

        
        StartCoroutine(SceneFadeAndTravel(index));

    }

    IEnumerator SceneFadeAndTravel(int sceneIndex)
    {
        screenfade.FadeOut();
        yield return new WaitForSeconds(screenfade.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
    public void ReloadScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}
