using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
	LevelManager levelManagerScript;
	WaypointsManager WMGameMaster;

	[SerializeField]
	Transform[] waypoints;

	/*[SerializeField]
	float moveSpeed;*/
	public float SlowingCooldown = 0f;
	public float moveSpeed;
	float fatenemySpeed = 0.3f;
	public int waypointIndex = 0;
	public Health HealthScript;
	public AlienScript alienScript;



	public bool fatenemy1;
	public bool fatenemy2;
	public bool fatenemy3;

	public bool slowBoost;

	public bool disableIT;

	void Start()
	{
		if (!disableIT)
		{
			WMGameMaster = GameObject.Find("GameMaster").GetComponent<WaypointsManager>();
			waypoints = WMGameMaster.waypoints;
		}
		alienScript = gameObject.GetComponent<AlienScript>();
		if (waypoints.Length > 0)
		{
			//transform.position = waypoints[waypointIndex].transform.position;
		}
		//access the Level Manager (levelManagerScript._______)
		//levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

	void Update()
	{
	
		SlowingCooldown -= Time.deltaTime;
		if (waypoints.Length > 0)
		{
			Move();
		}


		Slow();
		SlowBoost();
	}
	void SlowBoost()
    {
		if(slowBoost)
        {
			if (!fatenemy1 && !fatenemy2 && !fatenemy3)
			{
				if (HealthScript.AlienEnemy && alienScript.InvinclibleEnabled)
				{
					moveSpeed = 1f;
				}
				else
				{
					moveSpeed = 0.5f;
				}
			}

			if (fatenemy1)
			{
				moveSpeed = fatenemySpeed-0.1f;
			}

			if (fatenemy2)
			{
				moveSpeed = fatenemySpeed + 0.6f;
			}

			if (fatenemy3)
			{
				moveSpeed = fatenemySpeed + 1.2f;
			}

		}
		if (!slowBoost && SlowingCooldown <= 0)
		{
			if (fatenemy1)
			{
				moveSpeed = fatenemySpeed;
			}

			if (fatenemy2)
			{
				moveSpeed = fatenemySpeed + 1f;
			}

			if (fatenemy3)
			{
				moveSpeed = fatenemySpeed + 2f;
			}

			if (!fatenemy1 && !fatenemy2 && !fatenemy3)
			{
				moveSpeed = 1f;
			}
		}

		if (moveSpeed < 0f)
        {
			moveSpeed = 0.1f;
			Debug.Log("Enemies speed is below 0");
		}
    }

	void Slow()
    {
		if (SlowingCooldown > 0)
		{
			if (!fatenemy1 && !fatenemy2 && !fatenemy3)
			{
				if (HealthScript.AlienEnemy && alienScript.InvinclibleEnabled)
				{
					moveSpeed = 1f;
				}
				else
				{
					moveSpeed = 0.5f;
				}
			}

			if (fatenemy1)
			{
				moveSpeed = fatenemySpeed - 0.1f;
			}

			if (fatenemy2)
			{
				moveSpeed = fatenemySpeed + 0.6f;
			}

			if (fatenemy3)
			{
				moveSpeed = fatenemySpeed + 1.2f;
			}


		}
		if (SlowingCooldown <= 0)
		{
			if (fatenemy1)
			{
				moveSpeed = 0.3f;
			}

			if (fatenemy2)
			{
				moveSpeed = 1.5f;
			}

			if (fatenemy3)
			{
				moveSpeed = 3f;
			}

			if (!fatenemy1 && !fatenemy2 && !fatenemy3)
			{
				moveSpeed = 1f;
			}

		}
	}
	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

		if (transform.position == waypoints[waypointIndex].transform.position)
		{
			waypointIndex += 1;
		}

		if (waypointIndex == waypoints.Length)
		{
			Destroy(transform.parent.gameObject);
			//Destroy(gameObject, 1f);
			//waypointIndex = 0;
			//lose a life
		}
	}

}
