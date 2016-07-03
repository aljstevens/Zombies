using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public float GunShot =2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		GunShot -= Time.deltaTime; 

		if (GunShot <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
