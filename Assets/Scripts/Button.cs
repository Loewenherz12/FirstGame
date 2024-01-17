using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    private bool pressed;

    public GameObject whatOpens; // Referenz auf das Objekt, das ge�ffnet werden soll

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hier k�nnen Sie weitere Logik f�r den Button implementieren, wenn n�tig
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pressed)
        {
            Debug.Log("Button pressed");
            anim.SetBool("ButtonPresed", true);
            pressed = true;

            // �berpr�fen, ob das, was ge�ffnet werden soll, eine Fallt�r ist
            Fallt�r doorScript = whatOpens.GetComponent<Fallt�r>();
            if (doorScript != null)
            {
                // Wenn ja, rufen Sie die OpenDoor-Funktion auf der Fallt�r auf
                doorScript.OpenDoor();
            }

            // Hier k�nnen Sie weitere Aktionen ausf�hren, wenn der Button gedr�ckt wird
        }
    }
}