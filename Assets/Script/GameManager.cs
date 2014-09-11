using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public int Score = 0;
	public GUISkin Skin;

	void Start()
	{
		Score = 0;
	}

	void OnGUI()
	{
		GUI.skin = Skin;
		GUI.Label (new Rect (35, Screen.height - 40, Screen.width / 3, Screen.height / 4), "" + Score);
	}

	public void ResetGame()
	{
		Score = 0;
	}

	static public void AddScore()
	{
		Score += 10;
		Ennemy.Speed += 0.2f;
		SpawnDragon.SpawnSpeed -= 0.1f;
	}
}
