using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour {
	public void onContinueClick() {
		LevelManager.difficulty = LevelUtility.calculateRankedDifficulty();
    LevelManager.level = LevelUtility.calculateRankedLevel();
		GameManager.Load("Game");
	}
}
