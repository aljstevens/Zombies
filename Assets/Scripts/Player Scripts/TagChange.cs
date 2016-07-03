using UnityEngine;
using System.Collections;

public class TagChange : MonoBehaviour {

	private float Timer=1f;
	private TagChange tagchange;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Timer -= Time.deltaTime;

		if (Timer <= 0) 
		{
			gameObject.tag = ("Soldier");
			tagchange= GetComponent <TagChange> ();
			tagchange.enabled = false;
		}
	}
}
