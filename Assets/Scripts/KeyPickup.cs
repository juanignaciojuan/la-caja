using UnityEngine;
using UnityEngine.InputSystem;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private float pickupDistance = 3f;
    [SerializeField] private LayerMask keyLayerMask;
    [SerializeField] private AudioSource pickupSound;
    [SerializeField] private DoorInteraction doorToUnlock;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private GameObject outlineVisual;

    private bool collected = false;
    private bool isHovered = false; // NEW: tracks hover state

    private void Start()
    {
        if (playerCamera == null && Camera.main != null)
            playerCamera = Camera.main.transform;

        if (outlineVisual != null)
            outlineVisual.SetActive(false);
    }

    private void Update()
    {
        if (collected || playerCamera == null) return;

        bool hitThisFrame = false;

        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickupDistance, Color.red);
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance, keyLayerMask))
        {
            if (hit.collider.gameObject == gameObject)
            {
                hitThisFrame = true;

                if (!isHovered) // just started hovering
                {
                    EnableOutline();
                    UIManager.instance.ShowLiveMessage("Tomar la llave");
                    isHovered = true;
                }

                if (Mouse.current.leftButton.wasPressedThisFrame)
                    PickupKey();
            }
        }

        // Instantly disable when not looking
        if (!hitThisFrame && isHovered)
        {
            DisableOutline();
            UIManager.instance.ClearMessage();
            isHovered = false;
        }
    }

    private void PickupKey()
    {
        collected = true;

        GameManager.instance.hasKey = true;

        UIManager.instance.ClearMessage();
        UIManager.instance.ShowMessage("Llave tomada");

        pickupSound?.Play();

        /*if (doorToUnlock != null)
            doorToUnlock.Unlock();*/

        Destroy(gameObject, pickupSound != null ? pickupSound.clip.length : 0.1f);
    }

    public void EnableOutline() => outlineVisual?.SetActive(true);
    public void DisableOutline() => outlineVisual?.SetActive(false);
}
