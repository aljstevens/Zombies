using UnityEngine;
using System.Collections;

public class BarrelShot : MonoBehaviour {
	
	public float Health=1f;
	public bool PlayerIsAttacked;
	public GameObject Boom;

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
		if (Health <= 0)
		{
			Instantiate(Boom, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
		}

	}

	void OnMouseDown()
	{
		if (gun.GunLoaded == true) 
		{
			Debug.Log ("Clicked");
			Health -= gun.GunDamageAmount;
		}
			
	}
}
