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
    public GameObject bombObject;
    public GameObject ImageMushTank;

    public GameObject kamera;

    private float minYPosition;



    private bool allowRotation = true;

    public bool takeMush = false;
    public float mMush = 0;
    public GameObject Portal;
    public GameObject emptyPortal;



    public float distance;

    public float deepDistance;

    public float mSchlüssel;

    [SerializeField] private ParticleSystem testParticleSystem = default;

    public int health = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();

        minYPosition = kamera.transform.position.y;

        ImageMushTank.SetActive(false);
        takeMush = false;
        Portal.SetActive(false);
        emptyPortal.SetActive(true);
    }


    void Update()
    {
        

        if (health == 1)
        {
            die();
        }

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

        // X-Koordinate für die Raycasts
        float raycastX = transform.position.x - 0.45f;

        // Erster Raycast nach unten
        Vector2 raycastOrigin = new Vector2(raycastX, transform.position.y - deepDistance);
        RaycastHit2D hitdown = Physics2D.Raycast(raycastOrigin, -transform.up, distance, layermask);

        // Zweiter Raycast nach unten mit angepasster x-Koordinate
        float raycastX2 = transform.position.x + 0.45f; // Ändere die x-Koordinate nach Bedarf
        Vector2 raycastOrigin2 = new Vector2(raycastX2, transform.position.y - deepDistance); // Ändere die Tiefe nach Bedarf
        RaycastHit2D hitdown2 = Physics2D.Raycast(raycastOrigin2, -transform.up, distance, layermask);

        // Setze isgrounded basierend auf den Ergebnissen der Raycasts
        if (hitdown.collider != null || hitdown2.collider != null)
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }

        Debug.DrawRay(raycastOrigin, -transform.up * distance, Color.red);
        Debug.DrawRay(raycastOrigin2, -transform.up * distance, Color.yellow); // Farbe kann nach Bedarf geändert werden

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false;
        }



        //------------------------------------------------------------------------------------

        float richtung = Input.GetAxis("Horizontal");

        if (richtung != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
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
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.G)) 
        {
            die();
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

    public void die()
    {
        testParticleSystem.Play();
        panel.SetActive(true);
        Destroy(gameObject);
    }
    

    



    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "ground")
        {
            isgrounded = true;

        }

        if (collision.gameObject.tag == "Gegner")
        {

            die();
            panel.SetActive(true);

        }


        if (collision.gameObject.tag == "Eisentor" && mSchlüssel > 0)
        {
            mSchlüssel--;
            Eisentor.SetActive(false);


        }
        if (collision.gameObject.tag == "Brunnen")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mush")
        {
            takeMush = true;
            mMush++;
            Destroy(other.gameObject);
        }



        if (other.gameObject.tag == "TankMush")
        {
            if(mMush > 0)
            {
                takeMush = false;
                ImageMushTank.SetActive(true);
                emptyPortal.SetActive(false);
                Portal.SetActive(true);
                mMush--;
            }

        }




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

        if (other.gameObject.tag == "Bomb")
        {

            die();
            Bomb bombScript = bombObject.GetComponent<Bomb>();
            if (bombScript != null)
            {
                bombScript.explode();
            }

        }

        if (other.gameObject.tag == "Spike")
        {

            die();
        } 

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        
    }


}