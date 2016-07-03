using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public bool PlayerIsAttacked;
	public float Damage;
	public float Health;
	public bool ShieldActive;
	public bool ShieldDeactive;
	public float ShieldStartTime=0.2f;
	public Image ShieldBar;
	public Color ShieldColourActive;
	public Color ShieldColourDeactive;
	private float Width;
	private float WidthMax;

	// Use this for initialization
	void Start () 
	{
		Width = ShieldBar.rectTransform.sizeDelta.x;
		WidthMax = Width;
		//ShieldBar.rectTransform.sizeDelta = new Vector2 (10, 20);
		//ShieldBar.rectTransform.position = new Vector3 (10,49,28);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ShieldActive == true) 
		{
			ShieldBar.color = ShieldColourActive;
			if (ShieldStartTime >= 0f) 
			{
				ShieldStartTime -= Time.deltaTime;
			}

			if (ShieldStartTime <= 0f) 
			{
				ShieldStartTime = 0f;
			}
		}

		if (ShieldDeactive == true) 
		{
			ShieldBar.color = ShieldColourDeactive;
			if (ShieldStartTime <= 0.2f) 
			{
				ShieldStartTime += Time.deltaTime;
			}

			if (ShieldStartTime >= 0.2f) 
			{
				ShieldStartTime = 0.2f;
			}
		}
		
		if (Input.GetKey (KeyCode.Space) && ShieldActive == false && ShieldStartTime >= 0.2f)
			{
			Debug.Log ("Active");
			ShieldActive = true;
			ShieldDeactive = false;
			//ShieldStartTime = 0.6f;
			}

		if (Input.GetKey (KeyCode.Space) && ShieldActive == true && ShieldStartTime <=0)
		{
			Debug.Log ("Deactive");
			ShieldActive = false;
			ShieldDeactive = true;
			//ShieldStartTime = 0f;
		}

		if (PlayerIsAttacked == true && ShieldActive == false)
		{
			Health -= Damage;
			PlayerIsAttacked = false;
			Damage = 0f;
		}

		if (PlayerIsAttacked == true && ShieldActive == true)
		{
			Width -= Damage;
			PlayerIsAttacked = false;
			Damage = 0f;
		}
	}

	void FixedUpdate ()
	{
		ShieldBar.rectTransform.sizeDelta = new Vector2 (Width, 20);

		if (Width >= WidthMax) 
		{
			Width = WidthMax;
		}

		if (Width <= 0) 
		{
			Width = 0;
			ShieldStartTime = 0.2f;
			ShieldBar.color = ShieldColourDeactive;
			ShieldDeactive = true;
			ShieldActive = false;
		}

		if (ShieldActive == true)
		{
			Width -= 25 * Time.deltaTime;
		}

		if (ShieldDeactive == true)
		{
			Width += 10 * Time.deltaTime;
		}
	}
}
