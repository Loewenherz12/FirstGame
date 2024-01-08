using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spieler : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumph = 5;
    private bool isgrounded = false;

    private Animator anim;
    private Vector3 rotation;

    private CoinManager m;

    public GameObject panel;

    public GameObject kamera;

    private float minYPosition;



    


    // Neue Variable zur Steuerung der Rotation
    private bool allowRotation = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();

        minYPosition = kamera.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        kamera.transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, minYPosition), -10);

        float richtung = Input.GetAxis("Horizontal");

        if (richtung != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (allowRotation) // Überprüfen, ob die Rotation erlaubt ist
        {
            if (richtung < 0)
            {
                transform.eulerAngles = rotation - new Vector3(0, 180, 0);
                transform.Translate(Vector2.right * speed * -richtung * Time.deltaTime);
            }

            if (richtung > 0)
            {
                transform.eulerAngles = rotation;
                transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false;
        }
        if (isgrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }


        
    }

    //kamera.transform.position = new Vector3(transform.position.x, 0, -10);

    



    void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.tag == "ground")
        {
            isgrounded = true;
            
        }

        if (collision.gameObject.tag == "Gegner")
        {
            
            

                Destroy(gameObject);
                panel.SetActive(true);
            

        }

        
    }


    
        
       





    

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.tag == "Coin")
        {
            m.Addmoney();
            Destroy(other.gameObject);
        }



        if (other.gameObject.tag == "Spike")
        {

            Destroy(gameObject);
            panel.SetActive(true);
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        



    }


}