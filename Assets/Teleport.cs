using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TeleportTrigger"))
        {
            Vector3 targetPos = new Vector3(teleportTarget.position.x, teleportTarget.position.y, transform.position.z);
            transform.position = targetPos;
        }
    }
}
