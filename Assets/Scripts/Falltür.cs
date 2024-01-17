using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falltür : MonoBehaviour
{
    private Animator anim;
    private bool open;
    public GameObject mFalltür;
    private BoxCollider2D myBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Funktion, um die Falltür zu öffnen
    public void OpenDoor()
    {
        myBoxCollider.enabled = false;
        anim.SetBool("open", true);
        open = true;
        //mFalltür.SetActive(false);
        // Hier können Sie weitere Aktionen ausführen, wenn die Falltür gestartet wird
    }
}
