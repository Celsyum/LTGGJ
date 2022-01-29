using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	PlayerController pl;


	/**
	 * seconds
	 * */
	public float fireRate = 0.1f;


	private float canFire = 1f;
    // Start is called before the first frame update
    void Start()
    {
		pl = GetComponent<PlayerController>();
		canFire = fireRate;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool shoot()
	{
		if (canFire < 0)
		{
			canFire = fireRate;
			doShooting();
			return true;
		}
		canFire -= Time.deltaTime;
		return false;
	}

	void doShooting()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, this.transform.forward, 500);
		if (hit.collider != null)
		{
			// Calculate the distance from the surface and the "error" relative
			// to the floating height.
			//float distance = Mathf.Abs(hit.point.y - transform.position.y);
			//float heightError = floatHeight - distance;
			int layer = hit.collider.gameObject.layer;
			if (layer == 7 || layer == 8)
			{
				EnemyController en = hit.collider.GetComponent<EnemyController>();
			}
			
		}
	}
}
