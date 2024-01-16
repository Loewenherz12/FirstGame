using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image BarCd;
    public Geisterball geisterballObject;

    public float cd;
    public float maxCd;
    public float fillSpeed;

    // Start is called before the first frame update
    void Start()
    {
        

       
    }

    // Update is called once per frame
    public void Update()
    {
        cd += fillSpeed * Time.deltaTime;

        if (cd >= maxCd)
        {
            cd = 0f;
        }

        float fillAmount = cd / maxCd; // Berechnung des Füllwerts in Form eines Anteils
        BarCd.fillAmount = fillAmount; // Setzen des Füllwerts für das Image

       // Debug.Log("Current Value: " + cd);
    }
}
