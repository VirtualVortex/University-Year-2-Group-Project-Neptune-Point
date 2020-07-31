using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTouch : MonoBehaviour {

	public GameObject player;
	private Health script;

	void Start()
	{
		script = player.GetComponent<Health> ();
	}

	void OnTriggerEnter()
	{
		script.Heal ();
		Destroy (this.gameObject);
	}

}
