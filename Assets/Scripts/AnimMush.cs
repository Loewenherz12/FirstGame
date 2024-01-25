using UnityEngine;

public class AnimMush : MonoBehaviour
{
    public float schwebGeschwindigkeit = 1.0f; // Geschwindigkeit des Schwebens
    public float schwebStrecke = 1.0f; // Die maximale vertikale Strecke, die das Objekt zurücklegt

    private Vector2 ursprünglichePosition;
    private float aktuelleStrecke = 0.0f;
    private int richtung = 1; // 1 für aufwärts, -1 für abwärts

    // Start is called before the first frame update
    void Start()
    {
        ursprünglichePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Berechne die nächste Position des schwebenden Objekts
        float schwebBewegung = schwebGeschwindigkeit * Time.deltaTime * richtung;
        transform.Translate(Vector2.up * schwebBewegung);

        // Aktualisiere die aktuelle Strecke
        aktuelleStrecke += Mathf.Abs(schwebBewegung);

        // Wenn die maximale Strecke erreicht ist, ändere die Richtung
        if (aktuelleStrecke >= schwebStrecke)
        {
            richtung *= -1; // Ändere die Richtung umzukehren
            aktuelleStrecke = 0.0f; // Setze die aktuelle Strecke zurück
        }
    }
}
