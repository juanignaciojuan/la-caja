using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using StarterAssets;

public class GameStartManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject blackScreenObject;
    public Button playButton;
    public AudioSource introAudio;

    [Header("Fade Settings")]
    public float fadeDuration = 5f;
    public AnimationCurve fadeCurve;

    [Header("Player")]
    public FirstPersonController playerController;

    private Image blackScreen;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        blackScreen = blackScreenObject.GetComponent<Image>();
        playButton.onClick.AddListener(BeginGame);

        if (playerController != null)
            playerController.enabled = false;
    }

    public void BeginGame()
    {
        playButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        blackScreenObject.SetActive(true);
        if (introAudio != null) introAudio.Play();

        StartCoroutine(FadeAndEnablePlayer());
    }

    IEnumerator FadeAndEnablePlayer()
    {
        float t = 0f;
        Color color = blackScreen.color;

        while (t < fadeDuration)
        {
            float alpha = 1f - fadeCurve.Evaluate(t / fadeDuration);
            color.a = alpha;
            blackScreen.color = color;
            t += Time.deltaTime;
            yield return null;
        }

        color.a = 0;
        blackScreen.color = color;
        blackScreenObject.SetActive(false);

        float waitTime = Mathf.Max(0f, introAudio.clip.length - fadeDuration);
        yield return new WaitForSeconds(waitTime);

        if (playerController != null)
            playerController.enabled = true;
    }
}
