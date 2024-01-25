using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    

    [SerializeField] private ParticleSystem testParticleSystem = default;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void explode()
    {
        testParticleSystem.Play();
        Destroy(gameObject);
    }
    
}
