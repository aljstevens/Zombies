using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	
	public float Health=10f;
	public bool PlayerIsAttacked;

	private Gun gun;
	public GameObject Player;

	// Use this for initialization
	void Awake () 
	{
		if (Player == null)
		{
			Player = GameObject.FindWithTag ("Player");
		}

		if (gun == null)
		{
			gun = Player.GetComponent <Gun> ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		if (gun.GunLoaded == true) 
		{
			Debug.Log ("Clicked");
			Health -= gun.GunDamageAmount;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == ("Boom")) 
		{
			Health = 0f;
		}
	}
}
