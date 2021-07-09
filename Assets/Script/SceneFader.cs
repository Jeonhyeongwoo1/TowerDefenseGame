using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup canvas;
    public AnimationCurve animationCurve;
    public GameObject panel;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {

    }

    public void StartFade(float duration, bool isStart, UnityAction done)
    {
        panel.SetActive(true);
        StartCoroutine(Fade(duration, isStart, done));
    }

    public void ChangeScene(string SceneName)
    {
        panel.SetActive(true);
        StartCoroutine(Fade(0.3f, true, () => StartCoroutine(WaitDuration(1f, () => SceneManager.LoadScene(SceneName)))));
    }

    IEnumerator WaitDuration(float duration, UnityAction done)
    {
        yield return new WaitForSeconds(duration);
        done?.Invoke();
    }

    IEnumerator Fade(float duration, bool isStart, UnityAction done)
    {
        float start = isStart ? 0 : 1;
        float end = isStart ? 1 : 0;
        float elapsed = 0;

        //Time Scale 0일 경우에  DeltaTime 값 또한 0
        if (Time.timeScale == 0) { Time.timeScale = 1f; }

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(start, end, animationCurve.Evaluate(elapsed / duration));
            yield return null;
        }

        done?.Invoke();
    }
}
