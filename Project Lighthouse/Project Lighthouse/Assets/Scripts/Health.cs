using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	int health = 100;
	int newhealth;


	// Use this for initialization
	void Start () {
		Debug.Log ("Health: " + health);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayHealth(string message)
	{
		Debug.Log (message);
	}

	public void LowerHealth()
	{
		newhealth = health - 10;
		health = newhealth;

		Debug.Log ("Health:" + newhealth);
	}

	public void Heal()
	{
		health = 100;
		Debug.Log ("Health:" + health);
	}
}
