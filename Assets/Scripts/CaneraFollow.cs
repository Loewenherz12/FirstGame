using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 lastValidTargetPosition; // Speichert die letzte gültige Position des Ziels

    [SerializeField] private Transform target;

    void Update()
    {
        if (target != null)
        {
            lastValidTargetPosition = target.position; // Speichere die Position des Ziels, solange es gültig ist
            Vector3 targetPosition = lastValidTargetPosition + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            // Halte die Kamera an der letzten gültigen Position des Ziels, bevor es null wurde
            Vector3 targetPosition = lastValidTargetPosition + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
