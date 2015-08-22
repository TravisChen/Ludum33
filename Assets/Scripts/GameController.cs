using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

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

		Cursor.visible = false;
		Application.targetFrameRate = 60;

		RefManager.Instance.startUIContainer.gameObject.SetActive( false );
		RefManager.Instance.gameUIContainer.gameObject.SetActive( false );
		RefManager.Instance.endUIContainer.gameObject.SetActive( false );
	}

	void UpdateEscapeAndRestart()
	{
		if (Input.GetKey(KeyCode.Escape)) 
		{
			Application.Quit(); 
		} 
		
		if (Input.GetKey(KeyCode.R)) 
		{
			Application.LoadLevel(Application.loadedLevel);
		} 
	}
	
	// Update is called once per frame
	void Update () {

		UpdateEscapeAndRestart();

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
		RefManager.Instance.scoreLabel.text = "" + score + "";

		// Set time
		System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timer);
		string timerString = string.Format("{0:0}:{1:00}", timeSpan.Minutes, timeSpan.Seconds );
		RefManager.Instance.timerLabel.text = timerString;

		// Update time
		timer -= Time.deltaTime;
	}
	
	public void UpdateGameStart() {

		RefManager.Instance.startUIContainer.gameObject.SetActive( true );

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
			RefManager.Instance.startUIContainer.SetActive( false );
			RefManager.Instance.gameUIContainer.SetActive( true );
			gameStarted = true;
		}
	}
	
	public void UpdateGameOver() {

		RefManager.Instance.gameUIContainer.SetActive( false );
		RefManager.Instance.endUIContainer.SetActive( true );

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

