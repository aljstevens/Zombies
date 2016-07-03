using UnityEngine;
using System.Collections;

public class MouseShoot : MonoBehaviour {

	public GameObject yourObject;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
			if (Input.GetButtonDown ("Fire1")) 
			{
				var mousePos = Input.mousePosition;
				mousePos.z = 2.0f;       // we want 2m away from the camera position
				var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
				Instantiate(yourObject, objectPos, Quaternion.identity);
			}
		}
	}
