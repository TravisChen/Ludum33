using UnityEngine;
using System.Collections;

public class Exploder : MonoBehaviour {

	public ParticleSystem explode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Explode()
	{
		explode.Play();
	}
}
