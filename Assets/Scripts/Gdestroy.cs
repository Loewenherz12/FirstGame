using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gdestroy : MonoBehaviour
{
    public float dauer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, dauer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnCollisionEnter2D is called when this object collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
