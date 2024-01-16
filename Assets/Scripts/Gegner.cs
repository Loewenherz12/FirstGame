using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegner : MonoBehaviour
{
    public float speed = 3f;
    public float rechts;
    public float links;
    
    private Vector3 rotation;


    // Start is called before the first frame update
    void Start()
    {
        
        rechts = transform.position.x + rechts;
        links = transform.position.x - links;
        rotation = transform.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < links)
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
        }
        if (transform.position.x > rechts)
        {
            transform.eulerAngles = rotation;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Geisterball")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            
            
        }
    }
}