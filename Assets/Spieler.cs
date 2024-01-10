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
    public GameObject Eisentor;

    public GameObject kamera;

    private float minYPosition;


    
    private bool allowRotation = true;


    public float distance;

    public float deepDistance;

    public float mSchlüssel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();

        minYPosition = kamera.transform.position.y;
    }

    
    void Update()
    {

        //kamera.transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, minYPosition), -10);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

        int layermask = 1 << 8;
        layermask = ~layermask;


        float horizontalInput = Input.GetAxis("Horizontal");

        // Movement based on key being held down
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else // Stop movement if no key is pressed
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        Vector2 raycastOrigin = new Vector2(transform.position.x, transform.position.y - deepDistance); // Hier wird die Raycast-Startposition leicht unterhalb der Spielerposition festgelegt
        RaycastHit2D hitdown = Physics2D.Raycast(raycastOrigin, -transform.up, distance, layermask);

        // Rest deines Codes bleibt gleich...


        if (Input.GetKeyDown(KeyCode.Space) && isgrounded == true)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false;
        }

        


        if (hitdown.collider != null)
        {
            isgrounded = true;
            Debug.Log("Hit Ground! Collider Name: " + hitdown.collider.name);
        }
        else
        {
            isgrounded = false;
            Debug.Log("No Ground");
        }

        Debug.DrawRay(raycastOrigin, -transform.up * distance, Color.red); // Zeichnet die Raycast-Linie für Debug-Zwecke

        //RaycastHit2D hitright = Physics2D.Raycast(raycastOrigin, transform.right, distance, layermask);
        Debug.DrawRay(raycastOrigin, transform.right * distance, Color.green); // Zeichnet die Raycast-Linie für Debug-Zwecke

        
        Debug.DrawRay(raycastOrigin, -transform.right * distance, Color.blue); // Zeichnet die Raycast-Linie für Debug-Zwecke


        //------------------------------------------------------------------------------------

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

        if (isgrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }


        //RaycastHit2D hitleft = Physics2D.Raycast(transform.position, -transform.right, distance, layermask);
        /*
        if(hitleft.collider != null)
        {
           /Debug.Log(hitleft.collider.name);
        }
        if (hitright.collider != null)
        {
            Debug.Log(hitright.collider.name);
        }
        */
        /*
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

        */
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


        if (collision.gameObject.tag == "Eisentor" && mSchlüssel > 0)
        {
            mSchlüssel--;
            Eisentor.SetActive(false);


        }

    }




    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Coin")
        {
            m.Addmoney();
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "Schlüssel")
        {
            mSchlüssel++;
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