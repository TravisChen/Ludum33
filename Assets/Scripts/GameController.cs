using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject startUIContainer;
	public GameObject gameUIContainer;
	public GameObject endUIContainer;
	public TextMesh scoreLabel;
	public TextMesh timerLabel;

	private int score = 0;
	private float timer = 10.0f;
	private float resetTimer = 2.0f;
	private float startTimer = 2.0f;

	private bool startKey = false;
	private bool resetKey = false;
	private bool gameOver = false;
	private bool gameStarted = false;


	// Use this for initialization
	void Start () {
		
		Application.targetFrameRate = 60;

		startUIContainer.gameObject.SetActive( false );
		gameUIContainer.gameObject.SetActive( false );
		endUIContainer.gameObject.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {
		
		if( !gameStarted )
		{
			UpdateGameStart();
			return;
		}
		
		if( !gameOver && timer <= 0.0f )
		{
			gameOver = true;
		}
		
		if( gameOver )
		{
			UpdateGameOver();
			return;
		}

		// Set score
		scoreLabel.text = "" + score + "";

		// Set time
		System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timer);
		string timerString = string.Format("{0:0}:{1:00}", timeSpan.Minutes, timeSpan.Seconds );
		timerLabel.text = timerString;

		// Update time
		timer -= Time.deltaTime;
	}
	
	public void UpdateGameStart() {

		startUIContainer.gameObject.SetActive( true );

		if( !startKey )
		{
			if( Input.anyKey )
			{
				startKey = true;
			}
			return;
		}

		startTimer -= Time.deltaTime;
		if( startTimer < 0.0f )
		{
			startUIContainer.SetActive( false );
			gameUIContainer.SetActive( true );
			gameStarted = true;
		}
	}
	
	public void UpdateGameOver() {

		gameUIContainer.SetActive( false );
		endUIContainer.SetActive( true );

		if( !resetKey )
		{
			if( Input.anyKey )
			{
				resetKey = true;
			}
			return;
		}

		resetTimer -= Time.deltaTime;
		if( resetTimer < 0.0f )
		{
			// Reset game
			Application.LoadLevel( 0 );
		}
	}
}	

