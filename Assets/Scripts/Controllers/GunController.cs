using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	PlayerController pl;

	private float canFire = 1f;
    // Start is called before the first frame update
    void Start()
    {
		pl = GetComponent<PlayerController>();
		canFire = pl.fireRate;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool shoot()
	{
		if (canFire < 0)
		{
			canFire = pl.fireRate;
			return true;
		}
		canFire -= Time.deltaTime;
		return false;
	}
}
