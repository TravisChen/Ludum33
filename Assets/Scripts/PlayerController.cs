using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

	private FirstPersonController fpsController;
	
	// Use this for initialization
	void Start () {
	
		fpsController = GetComponent<FirstPersonController>();

	}

	public void SetActivePlayer( bool active )
	{
		fpsController.enabled = active;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
