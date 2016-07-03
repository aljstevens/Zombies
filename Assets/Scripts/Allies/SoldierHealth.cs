using UnityEngine;
using System.Collections;

public class SoldierHealth : MonoBehaviour {

	public bool SoldierIsAttacked;
	public float Damage;
	public float Health;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (SoldierIsAttacked == true)
		{
			Health -= Damage;
			SoldierIsAttacked = false;
			Damage = 0f;
		}
	}

	void FixedUpdate ()
	{
		
	}
}
