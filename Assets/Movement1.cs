using UnityEngine;
using System.Collections;

public class Movement1 : MonoBehaviour {

	public GameObject Player;
	public GameObject target;
	public GameObject target2;
	public GameObject DropShip;
	public GameObject Ambush;
	public GameObject ActualShip;
	public GameObject ShipTarget;

	public bool FirstPoint =true;
	public bool SecondPoint;
	public float MoveTime = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (FirstPoint == true)
		{
			//Player.transform.LookAt (target2.transform);
			Player.transform.position = Vector3.MoveTowards (Player.transform.position, target.transform.position, .1f);
		}

		if (SecondPoint == true)
		{
			Player.transform.position = Vector3.MoveTowards (Player.transform.position, target2.transform.position, 1f);
		}
	}

	void FixedUpdate ()
	{
		MoveTime -= Time.deltaTime;

		if (DropShip == null)
		{
			ActualShip.transform.position = Vector3.MoveTowards (ActualShip.transform.position, ShipTarget.transform.position, .5f);
		}

		if (MoveTime <= 0)
		{
			FirstPoint = false;
			SecondPoint = true;
			Destroy (DropShip);
		}

		if (MoveTime <= -5) 
		{
			Ambush.SetActive (true);
		}
	}

}


