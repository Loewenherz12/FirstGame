using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    
    int nextSceneIndex = 1; 
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void play()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void Hauptmen�()
    {
        SceneManager.LoadScene("Hauptmen�");

    }
    public void QuitGame()
    {
        // Anwendung beenden
        Application.Quit();
    }

}
