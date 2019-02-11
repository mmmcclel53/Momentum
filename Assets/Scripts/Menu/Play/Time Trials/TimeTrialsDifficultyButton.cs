using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeTrialsDifficultyButton : MonoBehaviour {
  public void onDifficultyClick(string difficulty) {
    LevelManager.difficulty = difficulty;
    LevelManager.currentSolved = 0;
    LevelManager.time = 0;
    LevelManager.level = LevelUtility.calculateTimeTrialLevel();
    GameManager.Load("Game");
	}
}
