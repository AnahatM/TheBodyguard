using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image fadeImage;

    [Header("Transition Values")]
    [SerializeField] private AnimationCurve fadeAnimationCurve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string targetScene)
    {
        // Smoothly Transition Between Scenes
        StartCoroutine(FadeOut(targetScene));
    }

    // Scene Loading Functions
    public void ReloadScene() => FadeTo(SceneManager.GetActiveScene().name);

    private IEnumerator FadeIn()
    {
        // Fade In Using Animation Curve
        float t = 1f;
        while (t > 0f)
        {
            Time.timeScale = 1;
            t -= Time.deltaTime;
            float a = fadeAnimationCurve.Evaluate(t);
            fadeImage.color = new Color(0, 0, 0, a);
            yield return 0;
        }
    }

    private IEnumerator FadeOut(string targetScene)
    {
        // Fade Out Using Reversed Animation Curve
        float t = 0f;
        while (t < 1f)
        {
            Time.timeScale = 1;
            t += Time.deltaTime;
            float a = fadeAnimationCurve.Evaluate(t);
            fadeImage.color = new Color(0, 0, 0, a);
            yield return 0;
        }

        // Load Target Scene
        SceneManager.LoadScene(targetScene);
    }
}
