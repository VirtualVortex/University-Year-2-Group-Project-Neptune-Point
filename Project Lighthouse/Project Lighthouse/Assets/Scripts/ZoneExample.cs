using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneExample : MonoBehaviour {

	public GameObject player;
	private Health script;

	void Start()
	{
		script = player.GetComponent<Health> ();
	}

	void OnTriggerEnter()
	{
		
		script.DisplayHealth ("test");
		StartCoroutine (DecreaseHealth ());

	}
	void OnTriggerExit()
	{
		StopCoroutine ("DecreaseHealth");
	}

	private IEnumerator DecreaseHealth()
	{
		for (int i = 1; i < 7; i++) {
			script.LowerHealth ();
			yield return new WaitForSeconds (1);
		}

	}
}
