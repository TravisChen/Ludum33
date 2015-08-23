using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

	private FirstPersonController fpsController;
	private GameController gameController;
	
	// Use this for initialization
	void Start () {
	
		fpsController = GetComponent<FirstPersonController>();
		gameController = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();

	}

	public void SetActivePlayer( bool active )
	{
		fpsController.enabled = active;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Kill()
	{
		gameController.GameOver();
	}
}
