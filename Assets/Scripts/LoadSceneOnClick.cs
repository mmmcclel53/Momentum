using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadSceneOnClick : MonoBehaviour {
	private GameManager GameManager;

	public void onDifficultyClick(string difficulty) {
		GameManager.Load("Game", "difficulty", difficulty);
	}
}
