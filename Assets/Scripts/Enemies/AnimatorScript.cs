using UnityEngine;
using System.Collections;

public class AnimatorScript : MonoBehaviour {

	Animator anim;
	public bool AttackAnim;
	public bool Play;
	public bool Walk;
	public Transform target;
	NavMeshAgent agent;
	private Shot shot;
	private PlayerHealth playerhealth;
	private GameObject PlayerHitBox;
	public float Damage;
	private bool Alive = true;
	public float AttackTime;
	public bool Attacking;
	public bool InRange;
	private BoxCollider boxcollider;
	private float FallenTime =3f;
	public GameObject AttackPoint;
	public GameObject ClosestSoldier;
	private GameObject SoldierHitBox;
	private SoldierHealth soldierhealth;
	public GameObject Player;


	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindWithTag ("Player");
		PlayerHitBox = GameObject.FindWithTag ("PlayerHealth");
		playerhealth = PlayerHitBox.GetComponent <PlayerHealth> ();
		anim = GetComponent<Animator>();
		agent = GetComponent <NavMeshAgent> ();
		shot = GetComponentInChildren <Shot> ();

	}	

	GameObject FindClosestEnemy() 
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Soldier");
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

	// Update is called once per frame
	void Update () 
	{
		ClosestSoldier = FindClosestEnemy ();

		if (ClosestSoldier != null && agent.enabled == true)
		{
			agent.enabled = true;
			agent.Resume ();
			target = ClosestSoldier.transform;
		}

		if (ClosestSoldier == null && agent.enabled == true)
		{
			agent.enabled = true;
			agent.Resume ();
			target = Player.transform;
		}
	
		if (Alive == false) 
		{
			FallenTime -= Time.deltaTime;
		}

		if (FallenTime <= 0) 
		{
			Destroy (gameObject);
		}
		
		if (shot.Health <= 0 && Alive == true) 
		{
			anim.SetTrigger ("Killed");
			Debug.Log ("Hi");
			Alive = false;
//			agent.Stop (true);
			boxcollider = GetComponent<BoxCollider> ();
			boxcollider.enabled = false;
			agent.enabled = false;
		}

		if (shot.Health >= 1)
		{
			if (agent.enabled == true)
			{
				agent.SetDestination (target.position);
			}
			if (AttackAnim == true) 
			{
				anim.SetTrigger ("Attack");
				AttackAnim = false;
			}
				

			if (Walk == true) {
				anim.SetTrigger ("Walk");
				Walk = false;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (target != null)
		{
			if (other.gameObject == target.gameObject && InRange == false && shot.Health >= 1) {//(other.gameObject == (target.gameObject) && InRange == false && shot.Health >= 1 && target != null)
				Debug.Log ("Yep");
				//	agent.Stop (true);
				agent.enabled = false;
				AttackTime = Random.Range (1, 4);
				Attacking = true;
				InRange = true;
				AttackPoint = other.gameObject;
			}
		}
	}

	void FixedUpdate ()
	{
		if (AttackPoint == null) 
		{
			AttackPoint = null;
			agent.enabled = true;
			InRange = false;
		}

		if (Attacking == true && AttackPoint != null) 
		{
			transform.LookAt (AttackPoint.transform);
		}
		
		if (shot.Health >= 1)
		{
			if (Attacking == true) 
			{
				AttackTime -= Time.deltaTime;
			}

			if (Attacking == true && AttackTime <= 0  && AttackPoint != null)
			{
				if (AttackPoint == Player && AttackPoint != null) //)AttackPoint.tag == ("Solider") && AttackPoint != null )//&& AttackPoint == Player)
					{
					Debug.Log ("Why");
				playerhealth.PlayerIsAttacked = true;
				playerhealth.Damage = Damage ;
				AttackAnim = true;
				AttackTime = Random.Range (1, 4);
					}

				if (AttackPoint.tag == ("Soldier") && AttackPoint != null && AttackPoint != Player)
				{
					SoldierHitBox =AttackPoint;
					soldierhealth = SoldierHitBox.GetComponent <SoldierHealth> ();
					soldierhealth.SoldierIsAttacked = true;
					soldierhealth.Damage = Damage ;
					AttackAnim = true;
					AttackTime = Random.Range (1, 4);

					if (soldierhealth.Health <= 0) 
					{
						AttackPoint = null;
						InRange = false;
						agent.enabled = true;
						Destroy (SoldierHitBox);
					}
				}
			}
		}
	}

}
