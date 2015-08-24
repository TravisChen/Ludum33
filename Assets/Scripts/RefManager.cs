﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefManager : MonoBehaviour {

	[Header("UI")]
	public GameObject startUIContainer;
	public GameObject gameUIContainer;
	public GameObject endUIContainer;
	public TextMesh scoreLabel;
	public TextMesh timerLabel;
	public Material fadeToBlack;

	// Static singleton property
	public static RefManager Instance { get; private set; }
	
	void Start()
	{
	}
	
	void Update()
	{
	}

	
	void Awake()
	{
		AwakeInstance();
	}
	
	void AwakeInstance()
	{
		// First we check if there are any other instances conflicting
		if(Instance != null && Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}
		
		// Here we save our singleton instance
		Instance = this;
		
		// Furthermore we make sure that we don't destroy between scenes (this is optional)
		DontDestroyOnLoad(gameObject);
	}
}