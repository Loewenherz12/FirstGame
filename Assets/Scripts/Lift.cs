using UnityEngine;

public class AufzugSkript : MonoBehaviour
{
    public float geschwindigkeit;
    public float maximaleHoehe;
    private bool start = false;
    private Vector3 urspruenglichePosition;

    void Start()
    {
        // Speichere die urspr�ngliche Position des Aufzugs beim Start.
        urspruenglichePosition = transform.position;
    }

    void FixedUpdate()
    {
        if (start)
        {
            BewegeNachOben();
        }

        // �berpr�fe, ob der Aufzug seine urspr�ngliche Position erreicht hat.
        if (transform.position.y <= urspruenglichePosition.y)
        {
            // Setze start auf false, wenn die urspr�ngliche Position erreicht ist.
            start = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !start)
        {
            // Wenn das Objekt mit dem Tag "Player" den Aufzug ber�hrt und der Aufzug noch nicht gestartet ist, starte den Aufzug nach oben.
            start = true;
        }
    }


    void BewegeNachOben()
    {
        transform.Translate(Vector2.up * geschwindigkeit * Time.deltaTime);

        // �berpr�fe, ob der Aufzug �ber oder unter der urspr�nglichen Position ist.
        if (transform.position.y >= maximaleHoehe)
        {
            // Hier kannst du zus�tzlichen Code hinzuf�gen, wenn die maximale H�he erreicht ist.
            // Zum Beispiel die Richtung umkehren, um nach unten zu bewegen.
            geschwindigkeit = -geschwindigkeit;
        }

        // �berpr�fe, ob der Aufzug unter der urspr�nglichen Position ist.
        if (transform.position.y < urspruenglichePosition.y)
        {
            // Setze den Aufzug auf die urspr�ngliche Position zur�ck.
            transform.position = urspruenglichePosition;

            // Optional: �ndere die Richtung, um nach oben zu bewegen.
            geschwindigkeit = Mathf.Abs(geschwindigkeit);
        }
    }

}
