using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schlüssel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
            // Spieler hat den Schlüssel eingesammelt
            gameObject.SetActive(false); // Schlüssel ausblenden oder zerstören
            Eisentor.EisentorFreischalten(); // Aufruf der Methode im EisentorSkript
        
    }
}
