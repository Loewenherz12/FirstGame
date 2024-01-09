using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Geisterball : MonoBehaviour
{
    public Transform Gspawn;
    public Rigidbody2D GPrefab;
    Rigidbody2D clone;
    public float Gspeed = 450;

    public Image BarCd;

    public float cd;
    public float maxCd;
    public float fillSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Gspawn = GameObject.Find("Gspawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (cd < maxCd)
        {
            cd += fillSpeed * Time.deltaTime;
            cd = Mathf.Clamp(cd, 0, maxCd); // Stopping cd at maxCd
            float fillAmount = cd / maxCd; // Berechnung des Füllwerts in Form eines Anteils
            BarCd.fillAmount = fillAmount; // Setzen des Füllwerts für das Image
        }

        if (Input.GetButtonDown("Fire1") && Mathf.Approximately(cd, maxCd))
        {
            Attack();
            cd = 0;
        }

        Debug.Log("Current Value: " + cd);
    }

    public void Attack()
    {
        clone = Instantiate(GPrefab, Gspawn.position, Gspawn.rotation);
        clone.AddForce(Gspawn.transform.right * Gspeed);
    }
}
