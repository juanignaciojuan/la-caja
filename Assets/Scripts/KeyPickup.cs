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

        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickupDistance, Color.red);

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance, keyLayerMask))
        {
            if (hit.collider.gameObject == gameObject)
            {
                EnableOutline();

                if (UIManager.instance != null)
                    UIManager.instance.ShowLiveMessage("Tomar la llave");

                if (Mouse.current.leftButton.wasPressedThisFrame)
                    PickupKey();
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
    }

    private void PickupKey()
    {
        collected = true;

        if (GameManager.instance != null)
            GameManager.instance.hasKey = true;

        if (UIManager.instance != null)
        {
            UIManager.instance.ClearMessage();
            UIManager.instance.ShowMessage("Llave tomada");
        }

        if (pickupSound != null)
            pickupSound.Play();

        if (doorToUnlock != null)
            doorToUnlock.Unlock();

        Destroy(gameObject, pickupSound != null ? pickupSound.clip.length : 0.1f);
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
