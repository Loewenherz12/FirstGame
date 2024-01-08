

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geisterball : MonoBehaviour
{
    public Transform Gspawn;

    public Rigidbody2D GPrefab;
    Rigidbody2D clone;

    public float Gspeed = 450;

    // Start is called before the first frame update
    void Start()
    {
        Gspawn = GameObject.Find("Gspawn").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Attack();
        }
        
    }
    void Attack()
    {
        clone = Instantiate(GPrefab, Gspawn.position, Gspawn.rotation);
        clone.AddForce (Gspawn.transform.right*Gspeed);
    }
}