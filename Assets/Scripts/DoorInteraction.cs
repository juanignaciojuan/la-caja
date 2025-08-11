using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private float rotationAngle = 90f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private bool requiresKey = false;
    [SerializeField] private float interactionDistance = 5f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private GameObject outlineVisual;

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private AudioSource unlockSound;
    [SerializeField] private AudioSource lockedSound;

    private bool doorOpen = false;
    private bool isRotating = false;
    private bool wasUnlocked = false;
    private Quaternion targetRotation;

    private Transform pivot; // Rotates this (parent of door)

    private void Start()
    {
        if (playerCamera == null && Camera.main != null)
            playerCamera = Camera.main.transform;

        pivot = transform.parent;

        if (outlineVisual != null)
            outlineVisual.SetActive(false);
    }

    private void Update()
    {
        if (playerCamera == null) return;

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.blue);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                EnableOutline();

                if (Mouse.current.leftButton.wasPressedThisFrame)
                    TryInteract();
                else
                    ShowHoverMessage();
            }
            else
            {
                DisableOutline();
                if (UIManager.instance != null)
                    UIManager.instance.ClearMessage();
            }
        }
        else
        {
            DisableOutline();
            if (UIManager.instance != null)
                UIManager.instance.ClearMessage();
        }

        if (isRotating && pivot != null)
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            if (Quaternion.Angle(pivot.rotation, targetRotation) < 0.1f)
            {
                pivot.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    public void TryInteract()
    {
        if (requiresKey && (GameManager.instance == null || !GameManager.instance.hasKey))
        {
            if (UIManager.instance != null)
                UIManager.instance.ShowMessage("Puerta cerrada");

            if (lockedSound != null)
                lockedSound.Play();

            return;
        }

        if (requiresKey && !wasUnlocked)
            Unlock();

        ToggleDoor();
    }

    public void ShowHoverMessage()
    {
        if (requiresKey && (GameManager.instance == null || !GameManager.instance.hasKey))
        {
            if (UIManager.instance != null)
                UIManager.instance.ShowLiveMessage("Puerta cerrada");
        }
        else
        {
            if (UIManager.instance != null)
                UIManager.instance.ShowLiveMessage(doorOpen ? "Cerrar puerta" : "Abrir puerta");
        }
    }

    public void Unlock()
    {
        wasUnlocked = true;

        if (UIManager.instance != null)
            UIManager.instance.ShowMessage("Puerta desbloqueada");

        if (unlockSound != null)
            unlockSound.Play();
    }

    private void ToggleDoor()
    {
        float angle = doorOpen ? -rotationAngle : rotationAngle;
        targetRotation = Quaternion.Euler(0, pivot.eulerAngles.y + angle, 0);
        isRotating = true;
        doorOpen = !doorOpen;

        if (doorOpen && openSound != null)
            openSound.Play();
        else if (!doorOpen && closeSound != null)
            closeSound.Play();
    }

    public void EnableOutline()
    {
        if (outlineVisual != null)
            outlineVisual.SetActive(true);
    }

    public void DisableOutline()
    {
        if (outlineVisual != null)
            outlineVisual.SetActive(false);
    }
}
