using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if( other.tag == "PlayerController" )
		{
			other.GetComponent<PlayerController>().Kill();
		}

	}
}
