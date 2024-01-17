using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    private bool pressed;

    public GameObject whatOpens; // Referenz auf das Objekt, das geöffnet werden soll

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hier können Sie weitere Logik für den Button implementieren, wenn nötig
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pressed)
        {
            Debug.Log("Button pressed");
            anim.SetBool("ButtonPresed", true);
            pressed = true;

            // Überprüfen, ob das, was geöffnet werden soll, eine Falltür ist
            Falltür doorScript = whatOpens.GetComponent<Falltür>();
            if (doorScript != null)
            {
                // Wenn ja, rufen Sie die OpenDoor-Funktion auf der Falltür auf
                doorScript.OpenDoor();
            }

            // Hier können Sie weitere Aktionen ausführen, wenn der Button gedrückt wird
        }
    }
}