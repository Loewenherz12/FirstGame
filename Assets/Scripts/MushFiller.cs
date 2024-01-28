using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class MushFiller : MonoBehaviour
{
    public Image Mush;

    public float mushcd;
    public float mushmaxCd;
    public float mushfillSpeed;

    public GameObject UIMush;

    // Declare playerSkript as a class-level variable
    private Spieler playerSkript;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the playerSkript reference in the Start method
        playerSkript = FindObjectOfType<Spieler>();
        mushcd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSkript.takeMush)
        {
            

            if (mushcd < mushmaxCd)
            {
                mushcd += mushfillSpeed * Time.deltaTime;
                mushcd = Mathf.Clamp(mushcd, 0, mushmaxCd); // Stopping cd at maxCd
                float fillAmount = mushcd / mushmaxCd; // Berechnung des Füllwerts in Form eines Anteils
                Mush.fillAmount = fillAmount; // Setzen des Füllwerts für das Image
            }
            if (mushcd >= mushmaxCd && playerSkript != null)
            {
                playerSkript.die();
            }
        }
        






    }
}
