using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private float rotationAngle = 90f;
    [SerializeField] private float interactionDistance = 5f;
    [SerializeField] private Transform player; // 🔄 asignación automática abajo
    [SerializeField] private AudioSource doorSound;
    [SerializeField] private float rotationSpeed = 5f; // 🔄 suavidad de la animación

    private bool doorOpen = false;
    private Quaternion targetRotation;
    private bool isRotating = false;

    private void Awake()
    {
        // 🔁 Si no arrastraste el Player en el Inspector, intenta encontrarlo por tag
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        // 🎯 Solo actuamos si se presiona clic izquierdo
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= interactionDistance)
            {
                ToggleDoor();
            }
        }

        // 🎞️ Si se está rotando, aplicar suavizado
        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // 🔚 Detener rotación si ya casi llegó al ángulo final
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    private void ToggleDoor()
    {
        float angle = doorOpen ? -rotationAngle : rotationAngle;
        targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0);
        isRotating = true;
        doorOpen = !doorOpen;

        if (doorSound != null)
            doorSound.Play();
    }
}
