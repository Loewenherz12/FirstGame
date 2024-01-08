using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public bool destroy;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        destroy = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        destroy = true;
        
    }
}
