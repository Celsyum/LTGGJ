using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public AudioSource audiosource;
    public AudioClip clip;
    public float volume=0.5f;
    Rigidbody2D rb;

    float horizontal;
    float vertical;

public float runSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       this.gameObject.AddComponent<AudioSource>();
       this.GetComponent<AudioSource>().clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }     
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void Shoot () 
    {        
        this.GetComponent<AudioSource>().Play();
    }
    
}
