using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text messageText;
    public float messageDuration = 2f;

    private Coroutine messageCoroutine;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        if (messageText != null)
            messageText.text = "";
    }

    public void ShowMessage(string message)
    {
        if (messageCoroutine != null)
            StopCoroutine(messageCoroutine);

        messageCoroutine = StartCoroutine(ShowMessageRoutine(message));
    }

    private IEnumerator ShowMessageRoutine(string message)
    {
        messageText.text = message;
        yield return new WaitForSeconds(messageDuration);
        messageText.text = "";
    }

    public void ShowLiveMessage(string message)
    {
        messageText.text = message;
    }

    public void ClearMessage()
    {
        messageText.text = "";
    }

}

