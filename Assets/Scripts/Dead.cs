using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Dead : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


    }



    public void RestartScene()
    {
        // Den Index der aktuellen Szene abrufen
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Die aktuelle Szene neu laden
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void Restart()
    {
        SceneManager.LoadScene("LvL");
    }
   
}
