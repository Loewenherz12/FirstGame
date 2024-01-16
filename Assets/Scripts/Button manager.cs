using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttonmanager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

    }

    
    
       
    
    
    public void Restart()
    {
        // Den Index der aktuellen Szene abrufen
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Die aktuelle Szene neu laden
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void Pause()
    {
        SceneManager.LoadScene("Hauptmenü");
    }
}
