using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown destinationDropdown;

    // Scene names in the SAME ORDER as your dropdown options:
    // 0: Orbit  -> "SolarSystem"
    // 1: Moon -> "MoonScene"
    // 2: Mercury -> "MercuryScene"
    // 3: Venus   -> "VenusScene"
    // 4: Earth   -> "EarthScene"
    // 5: Mars    -> "MarsScene"
    // 6: Jupiter -> "JupiterScene"
    // 7: Saturn  -> "SaturnScene"
    // 8: Uranus  -> "UranusScene"
    // 9: Neptune -> "NeptuneScene"
    [SerializeField] private string[] sceneNames;

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

        SceneManager.LoadScene(sceneName);
    }
    public void ReloadScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}
