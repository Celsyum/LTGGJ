using GGJ.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public AudioSource audiosource;
    public AudioClip clip;
    public float volume=0.5f;
    public Transform rbTurret;
    public Transform rbHull;
	Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;
	GameStats stats;
	GunController gun;

	public float runSpeed = 20.0f;
	public float rotationSpeed = 720f;

	public Animator anim;
	bool IsDriving;

    // Start is called before the first frame update
    void Start()
    {
		stats = Game.GetModel<GameStats>();
		rb = GetComponent<Rigidbody2D>();
		gun = GetComponent<GunController>();
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource>().clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = Input.mousePosition - cam.WorldToScreenPoint(rbTurret.parent.position);
		
		if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }     
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SwapGuns();
		}
		if (rb.velocity != new Vector2(0, 0))
		{
			anim.SetBool("IsDriving", true);
		}
		else
		{
			anim.SetBool("IsDriving", false);
		}
	}

    void FixedUpdate()
    {
		rb.velocity = new Vector2(movement.x * runSpeed, movement.y * runSpeed);
		rb.MovePosition(rb.position + movement * runSpeed * Time.fixedDeltaTime);

		

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;

		rbTurret.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (movement != Vector2.zero)
		{
			Quaternion toRoation = Quaternion.LookRotation(Vector3.forward, movement);
			rbHull.rotation = Quaternion.RotateTowards(rbHull.rotation, toRoation, rotationSpeed * Time.fixedDeltaTime);
		}
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
