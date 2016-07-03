using UnityEngine;
using System.Collections;

public class SoldierAttack : MonoBehaviour {

	public GameObject EnemyTarget;
	public GameObject Flash;
	public GameObject GunBarrel; 
	private float AttackTime =1;
	private Shot shot;

	GameObject FindClosestEnemy() 
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	// Use this for initialization
	void Start ()
	{
		AttackTime = Random.Range (1, 3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (EnemyTarget != null) 
		{
			transform.LookAt (EnemyTarget.transform);
		}

		if (EnemyTarget == null) 
		{
			EnemyTarget = FindClosestEnemy ();
		}

		if (EnemyTarget != null) 
		{
			AttackTime -= Time.deltaTime;
		}

		if (AttackTime <= 0) 
		{
			shot = EnemyTarget.GetComponent <Shot> ();
			shot.Health -= 5;
			AttackTime = Random.Range (1, 3);
			Instantiate(Flash, GunBarrel.transform.position, GunBarrel.transform.rotation);

			if (shot.Health <= 0)
			{
				EnemyTarget = null;
			}
		}
	}
}
