using UnityEngine;

public class AnimMush : MonoBehaviour
{
    public float schwebGeschwindigkeit = 1.0f; // Geschwindigkeit des Schwebens
    public float schwebStrecke = 1.0f; // Die maximale vertikale Strecke, die das Objekt zur�cklegt

    private Vector2 urspr�nglichePosition;
    private float aktuelleStrecke = 0.0f;
    private int richtung = 1; // 1 f�r aufw�rts, -1 f�r abw�rts

    // Start is called before the first frame update
    void Start()
    {
        urspr�nglichePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Berechne die n�chste Position des schwebenden Objekts
        float schwebBewegung = schwebGeschwindigkeit * Time.deltaTime * richtung;
        transform.Translate(Vector2.up * schwebBewegung);

        // Aktualisiere die aktuelle Strecke
        aktuelleStrecke += Mathf.Abs(schwebBewegung);

        // Wenn die maximale Strecke erreicht ist, �ndere die Richtung
        if (aktuelleStrecke >= schwebStrecke)
        {
            richtung *= -1; // �ndere die Richtung umzukehren
            aktuelleStrecke = 0.0f; // Setze die aktuelle Strecke zur�ck
        }
    }
}
