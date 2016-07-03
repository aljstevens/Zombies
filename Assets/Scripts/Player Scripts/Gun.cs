using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public bool GunLoaded = true;
	public float GunDamageAmount;

	public bool UsingHandGun = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (UsingHandGun == true)
		{
			GunDamageAmount = 5f;
		}
	
	}

	void OnMouseDown()
	{
			Debug.Log ("Clicked2");

		}
}
