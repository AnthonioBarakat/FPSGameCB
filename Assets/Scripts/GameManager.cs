using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
	// This for the singleton pattern
	public static GameManager instance;


	// This to put inside the 2 characters
	[SerializeField]
	private GameObject[] weapons;


	// This will be filled based on the name of choose button in MainMenuController.cs
	private int _countryIndex;

	public int CountryIndex
	{
		get { return _countryIndex; }
		set { _countryIndex = value; }
	}


	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void OnEnable()
	{
		// add function to event
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	// This is the same declaration of the delegate for the event sceneLoaded
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "MainScene")
		{
			Instantiate(weapons[CountryIndex]);
		}
	}
}


