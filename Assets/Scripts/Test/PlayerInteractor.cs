using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 5f;
    [SerializeField] private Transform cameraTransform;  // 🔧 Inspector reference

    private void Start()
    {
        if (cameraTransform == null)
        {
            Camera mainCam = Camera.main;
            if (mainCam != null)
            {
                cameraTransform = mainCam.transform;
                Debug.Log("✅ PlayerInteractor found MainCamera.");
            }
            else
            {
                Debug.LogError("❌ PlayerInteractor: No camera found. Assign one manually.");
            }
        }
    }

    private void Update()
    {
        if (cameraTransform == null) return;

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.green);

            if (hit.collider.TryGetComponent(out DoorInteraction door))
            {
                if (Mouse.current.leftButton.wasPressedThisFrame)
                    door.TryInteract();
                else
                    door.ShowHoverMessage();
            }
        }
    }
}
