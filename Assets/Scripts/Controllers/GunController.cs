using GGJ.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	PlayerController pl;
	GameStats stats;

	public LineRenderer lineRenderer;

	private float canFire = 1f;

	GunData gunData = new GunData();

    // Start is called before the first frame update
    void Start()
    {
		if (lineRenderer == null) Debug.Log("lineRenderer not set");
		pl = GetComponent<PlayerController>();;
		stats = Game.GetModel<GameStats>();
		//gunStatus = GameStateEnum.Mater;
		findGunData(gunData.type);
		canFire = gunData.fireRate;
	}

	void findGunData(GunTypeEnum type)
	{
		foreach (GunData item in stats.guns)
		{
			if (item.type == type)
			{
				gunData = item;
				return;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool shoot()
	{
		if (canFire < 0)
		{
			canFire = gunData.fireRate;
			doShooting();
			return true;
		}
		canFire -= Time.deltaTime;
		return false;
	}

	public bool swap()
	{
		if (gunData.type == GunTypeEnum.Mater)
		{
			findGunData(GunTypeEnum.Antimater);
		} else findGunData(GunTypeEnum.Mater);
		canFire = 0;   ///reset gun shooting
		return true;
	}

	void doShooting()
	{
		switch (gunData.type)
		{
			case GunTypeEnum.Mater:
				projectileShooting();
				break;
			case GunTypeEnum.Antimater:
				raycastShooting(); 
				break;
			default:
				break;
		}
		
	}

	void projectileShooting()
	{
		Debug.Log("shoot projectile");
	}

	void raycastShooting()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, this.transform.forward, 500);
		if (hit.collider != null)
		{
			Debug.Log("shot1");
			// Calculate the distance from the surface and the "error" relative
			// to the floating height.
			//float distance = Mathf.Abs(hit.point.y - transform.position.y);
			//float heightError = floatHeight - distance;
			int layer = hit.collider.gameObject.layer;
			if (layer == 7 || layer == 8)
			{
				EnemyController en = hit.transform.GetComponent<EnemyController>();
				//en.Damage()

				lineRenderer.SetPosition(0, pl.transform.position);
				lineRenderer.SetPosition(1, hit.point);
			}

		} else
		{
			Debug.Log("shot2");
			Vector3 playerDirection = pl.transform.forward;
			Quaternion playerRotation = pl.transform.rotation;
			float spawnDistance = 300;

			Vector3 spawnPos = pl.transform.position + playerDirection * spawnDistance;

			lineRenderer.SetPosition(0, pl.transform.position);
			lineRenderer.SetPosition(1, spawnPos);
		}
	}
}
