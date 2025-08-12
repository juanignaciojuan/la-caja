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
    private bool isHovered = false; // NEW: tracks hover state
    private Quaternion targetRotation;
    private Transform pivot;

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

        bool hitThisFrame = false;

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.blue);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                hitThisFrame = true;

                if (!isHovered) // just started hovering
                {
                    EnableOutline();
                    ShowHoverMessage();
                    isHovered = true;
                }

                if (Mouse.current.leftButton.wasPressedThisFrame)
                    TryInteract();
            }
        }

        // If no longer looking at this door → instantly disable
        if (!hitThisFrame && isHovered)
        {
            DisableOutline();
            if (UIManager.instance != null)
                UIManager.instance.ClearMessage();
            isHovered = false;
        }

        // Door rotation
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
        if (requiresKey && (!GameManager.instance || !GameManager.instance.hasKey))
        {
            UIManager.instance.ShowMessage("Puerta cerrada");
            lockedSound?.Play();
            return;
        }

        if (requiresKey && !wasUnlocked)
        {
            Unlock();
        }        ToggleDoor();
    }

    public void ShowHoverMessage()
    {
        // If locked, show nothing until clicked
        if (requiresKey && (!GameManager.instance || !GameManager.instance.hasKey))
        {
            UIManager.instance.ShowLiveMessage("Abrir la puerta");
        }
        else
        {
            if (doorOpen)
                UIManager.instance.ShowLiveMessage("Cerrar la puerta");
            else
                UIManager.instance.ShowLiveMessage("Abrir la puerta");
        }
    }

    public void Unlock()
    {
        wasUnlocked = true;
        UIManager.instance.ShowMessage("Puerta desbloqueada");
        unlockSound?.Play();
    }

    private void ToggleDoor()
    {
        float angle = doorOpen ? -rotationAngle : rotationAngle;
        targetRotation = Quaternion.Euler(0, pivot.eulerAngles.y + angle, 0);
        isRotating = true;
        doorOpen = !doorOpen;

        if (doorOpen)
            openSound?.Play();
        else
            closeSound?.Play();
    }

    public void EnableOutline() => outlineVisual?.SetActive(true);
    public void DisableOutline() => outlineVisual?.SetActive(false);
}
