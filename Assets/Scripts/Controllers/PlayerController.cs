using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public AudioSource audiosource;
    public AudioClip clip;
    public float volume=0.5f;
    Rigidbody2D rb;
    public Camera cam;

    float horizontal;
    float vertical;
    Vector2 movement;
    Vector2 mousePos;

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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }     
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        rb.MovePosition(rb.position + movement * runSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos + rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
    }

    void Shoot () 
    {        
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 playerPosition = this.transform.position;
        //making the laser
        //Debug.DrawLine(playerPosition, mousePosition, Color.red, 1/60f);
        Physics2D.Raycast(transform.position, this.transform.forward, 500);        this.GetComponent<AudioSource>().Play();
    }
    
}
