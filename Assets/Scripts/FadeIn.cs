using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image blackScreen;
    public float duration = 5f;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(Fade());
    }

    System.Collections.IEnumerator Fade()
    {
        float time = 0;
        Color color = blackScreen.color;
        while (time < duration)
        {
            float alpha = curve.Evaluate(time / duration);
            color.a = 1f - alpha;
            blackScreen.color = color;
            time += Time.deltaTime;
            yield return null;
        }

        color.a = 0;
        blackScreen.color = color;
    }
}
