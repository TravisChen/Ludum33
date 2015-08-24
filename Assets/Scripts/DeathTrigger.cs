using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	public Exploder[] exploders;

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

			foreach( Exploder exploder in exploders )
			{
				exploder.Explode();
			}
		}

	}
}
