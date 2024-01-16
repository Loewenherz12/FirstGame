using UnityEngine;

public class AufzugSkript : MonoBehaviour
{
    public float geschwindigkeit;
    public float maximaleHoehe;
    private bool start = false;
    private Vector3 urspruenglichePosition;

    void Start()
    {
        // Speichere die ursprüngliche Position des Aufzugs beim Start.
        urspruenglichePosition = transform.position;
    }

    void FixedUpdate()
    {
        if (start)
        {
            BewegeNachOben();
        }

        // Überprüfe, ob der Aufzug seine ursprüngliche Position erreicht hat.
        if (transform.position.y <= urspruenglichePosition.y)
        {
            // Setze start auf false, wenn die ursprüngliche Position erreicht ist.
            start = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !start)
        {
            // Wenn das Objekt mit dem Tag "Player" den Aufzug berührt und der Aufzug noch nicht gestartet ist, starte den Aufzug nach oben.
            start = true;
        }
    }


    void BewegeNachOben()
    {
        transform.Translate(Vector2.up * geschwindigkeit * Time.deltaTime);

        // Überprüfe, ob der Aufzug über oder unter der ursprünglichen Position ist.
        if (transform.position.y >= maximaleHoehe)
        {
            // Hier kannst du zusätzlichen Code hinzufügen, wenn die maximale Höhe erreicht ist.
            // Zum Beispiel die Richtung umkehren, um nach unten zu bewegen.
            geschwindigkeit = -geschwindigkeit;
        }

        // Überprüfe, ob der Aufzug unter der ursprünglichen Position ist.
        if (transform.position.y < urspruenglichePosition.y)
        {
            // Setze den Aufzug auf die ursprüngliche Position zurück.
            transform.position = urspruenglichePosition;

            // Optional: Ändere die Richtung, um nach oben zu bewegen.
            geschwindigkeit = Mathf.Abs(geschwindigkeit);
        }
    }

}
