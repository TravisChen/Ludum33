using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

	private bool dead = false;
	private float fadeToBlackAlpha = 0.0f;
	private float fadeToBlackTimer = 1.0f;
	private float fadeToBlackSpeed = 0.01f;

	private FirstPersonController fpsController;
	private GameController gameController;
	private Camera mainCamera;
	private Animation cameraAnimation;
	
	// Use this for initialization
	void Start () {
	
		fpsController = GetComponent<FirstPersonController>();
		gameController = GameObject.FindWithTag( "GameController" ).GetComponent<GameController>();
		mainCamera = GameObject.FindWithTag( "MainCamera" ).GetComponent<Camera>();
		cameraAnimation = mainCamera.GetComponent<Animation>();

		RefManager.Instance.fadeToBlack.SetColor( "_Color", new Color( 0.0f, 0.0f, 0.0f, fadeToBlackAlpha ) );

	}

	public void SetActivePlayer( bool active )
	{
		fpsController.enabled = active;
	}
	
	// Update is called once per frame
	void Update () {
	
		if( dead )
		{
			fadeToBlackTimer -= Time.deltaTime;
			if( fadeToBlackTimer < 0.0f )
			{
				fadeToBlackAlpha += fadeToBlackSpeed;
				RefManager.Instance.fadeToBlack.SetColor( "_Color", new Color( 0.0f, 0.0f, 0.0f, fadeToBlackAlpha ) );
			}
		}
	}

	public void Kill()
	{
		dead = true;
		cameraAnimation.clip = cameraAnimation.GetComponent<Animation>().GetClip( "PlayerDeath" );
		cameraAnimation.Play();
		gameController.GameOver();
	}
}
