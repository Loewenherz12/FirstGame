using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    private Transition t;
    int nextSceneIndex = 1;
    [SerializeField] Animator trans;

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
    public void Hauptmenü()
    {
        SceneManager.LoadScene("Hauptmenü");

    }
    public void QuitGame()
    {
        // Anwendung beenden
        Application.Quit();
    }
    public void transiton()
    {
        trans.SetTrigger("transition");
    }
}
