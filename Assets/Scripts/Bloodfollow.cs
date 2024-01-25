using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Der Spieler, dem gefolgt werden soll
    public float followSpeed = 5f; // Geschwindigkeit, mit der das Objekt folgt

    void Update()
    {
        // Überprüfen Sie, ob der Spieler existiert
        if (player != null)
        {
            // Setzen Sie die Position des Verfolgungsobjekts auf die Spielerposition
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
