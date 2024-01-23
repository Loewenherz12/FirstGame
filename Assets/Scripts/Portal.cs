using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalScript : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D other)
    {
       
        
            LoadNextScene();
        
    }

    void LoadNextScene()
    {

        SceneManager.LoadScene("Hauptmenü");

    }
}

