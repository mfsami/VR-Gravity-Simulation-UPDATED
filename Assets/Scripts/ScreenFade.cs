using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade Instance { get; private set; }

    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (fadeCanvasGroup != null)
            fadeCanvasGroup.alpha = 0f;
    }

    public void FadeAndLoad(string sceneName)
    {
        if (fadeCanvasGroup == null)
        {
            Debug.LogError("ScreenFade: fadeCanvasGroup is not assigned.");
            return;
        }

        StartCoroutine(FadeAndSwitchScene(sceneName));
    }

    private IEnumerator FadeAndSwitchScene(string sceneName)
    {
        yield return StartCoroutine(Fade(0f, 1f));                    // fade to black
        yield return SceneManager.LoadSceneAsync(sceneName);          // load
        yield return null;                                            // wait a frame
        yield return StartCoroutine(Fade(1f, 0f));                    // fade back in
    }

    private IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        fadeCanvasGroup.alpha = from;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(from, to, t / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = to;
    }
}



