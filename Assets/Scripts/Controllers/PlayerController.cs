using GGJ.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public AudioSource audiosource;
    public AudioClip clip;
    public float volume=0.5f;
    public Rigidbody2D rbTurret;
    public Rigidbody2D rbHull;
    public Camera cam;

    float horizontal;
    float vertical;
    Vector2 movement;
    Vector2 mousePos;
	GameStats stats;
	GunController gun;

	public float runSpeed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
		stats = Game.GetModel<GameStats>();
		gun = GetComponent<GunController>();
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
        mousePos = Input.mousePosition - cam.WorldToScreenPoint(rbTurret.position);
		
		if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }     
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SwapGuns();
		}
    }

    void FixedUpdate()
    {
        rbHull.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        rbHull.MovePosition(rbHull.position + movement * runSpeed * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        rbTurret.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }

	void SwapGuns()
	{
		if (gun.swap())
		{
			Debug.Log("gun swapped");
		}
	}


	void Shoot () 
    {        
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 playerPosition = this.transform.position;
        //making the laser
        //Debug.DrawLine(playerPosition, mousePosition, Color.red, 1/60f);
        
		if (gun.shoot(mousePos))
		{			
			stats.BulletShots++;
			this.GetComponent<AudioSource>().Play();
		}
    }
    
    public void ReceiveDamage(float amount)
    {
        Debug.Log($"Received {amount} damage. Need health implementation");
    }
}
